using System;
using System.Text;
using System.IO;
using NXOpen;
using NXOpen.UF;
using NXOpen.Routing;
using System.Collections.Generic;
using NXOpen.Features;
using NXOpen.Assemblies;

namespace MP_to_Ground_v2
{

    class Class1
    {
        public static Session nxsession;
        public static UFSession uFSession;
        public static UI theUI;
        
        public static NXOpen.Part workpart;
        public static MultiPort[] multiPorts;
        public static List<MultiPort> LmultiPorts;
        public static Point[] landingPts;
        public static Logger mlogger = null;
        public Class1()
        {
            nxsession = Session.GetSession();
            uFSession = UFSession.GetUFSession();

            theUI = UI.GetUI();
            mlogger = Logger.getInstance();
            LmultiPorts = new List<MultiPort>();
            logSetup();
            doIt();
            nxsession.Parts.SaveAll(out bool anyPartsModified, out PartSaveStatus partSaveStatus);
        }

        private void logSetup()
        {
            DateTime dt = DateTime.Now;
            dt.ToString();
            
            //throw new NotImplementedException();
        }

        static void doIt()
        {
            workpart = nxsession.Parts.Work;
            //NXObject[] nXObjects = workpart.Layers.GetAllObjectsOnLayer(25);
            //string mPortJrnID = "PROTO#" + nXObjects[0].JournalIdentifier;
            //NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)workpart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
            //NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
            //NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-3 1");
            //NXOpen.Routing.MultiPort multiPort1 = (NXOpen.Routing.MultiPort)component3.FindObject("PROTO#HANDLE R-603");
            //NXOpen.Assemblies.Component component4 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
            //NXOpen.Routing.MultiPort multiPort2 = (NXOpen.Routing.MultiPort)component4.FindObject("PROTO#HANDLE R-1353");
            //multiPorts[0] = multiPort1;
            //multiPorts[1] = multiPort2;
            
            NXOpen.Assemblies.Component rootComp = workpart.ComponentAssembly.RootComponent;
            findMultiPorts(rootComp);
            mlogger.writeLog("Multiports collection complete...");
            mlogger.flushLog();
            multiPorts = new MultiPort[LmultiPorts.Count];
            LmultiPorts.CopyTo(multiPorts);
            multiPort_to_Grnd();
        }

        private static void findMultiPorts(Component component1)
        {
            if (component1.GetChildren().Length == 0)
            {
                nxsession.Parts.SetWorkComponent(component1,PartCollection.RefsetOption.Entire, PartCollection.WorkComponentOption.Visible, out PartLoadStatus partLoadStatus);
                workpart = nxsession.Parts.Work;
                MultiPort[] Mport = workpart.RouteManager.MultiPorts.ToArray();
                if (Mport.Length != 0)
                {
                    foreach (var mp in Mport)
                    {
                        LmultiPorts.Add(mp);
                    }
                }
            }
            else
                foreach (Component item in component1.GetChildren())
                    findMultiPorts(item);

            /*To set main assembly as workpart*/
            NXOpen.Assemblies.Component null_nxopen_comp = null;
            nxsession.Parts.SetWorkComponent(null_nxopen_comp, PartCollection.RefsetOption.Entire, PartCollection.WorkComponentOption.Visible, out PartLoadStatus prtLoadStatus);
            workpart = nxsession.Parts.Work;
        }

        private static void multiPort_to_Grnd()
        {
            List<Point> intermediatepts = new List<Point>();
            //Feature[] features = workpart.Features.GetFeatures();

            //int x = 0;
            //for (int i = 0; i < features.Length; i++)
            //{
            //    if (features[i].FeatureType == "POINT")
            //    {
            //        string jrnID = features[i].JournalIdentifier;
            //        PointFeature pointFeature = (PointFeature)workpart.Features.FindObject(jrnID);
            //        landingPts.SetValue((Point)pointFeature.FindObject("POINT 1"), x);
            //        x++;
            //    }
            //}

            Point[] points = workpart.Points.ToArray();
            landingPts = Array.FindAll(points, a => a.Layer == 98);

            for (int i = 0; i < multiPorts.Length; i++)
            {
                if (!multiPorts[i].HasUserAttribute("is_MP_to_Ground_done", NXObject.AttributeType.Boolean, -1))
                {
                    NXOpen.Direction mpDir;
                    mpDir = workpart.Directions.CreateDirection(multiPorts[i], Sense.Forward, SmartObject.UpdateOption.WithinModeling);

                    Scalar scalar = workpart.Scalars.CreateScalar(0.0, Scalar.DimensionalityType.Length, SmartObject.UpdateOption.WithinModeling);
                    Point startPt = workpart.Points.CreatePointOnPortExtractAlign(SmartObject.UpdateOption.WithinModeling, multiPorts[i], scalar);
                    int ptInd = -1;
                    closestPt(startPt, landingPts, out ptInd);
                    // create two points at 25 and 95% between mp and landing point and offset by 20 and 2 mm
                    //double[] dparams = { 25.0, 75.0 };
                    //double[] doffset = { 5.0, 2.0 };

                    double[] dparams;
                    double[] doffset;
                    Params myParams = new Params();
                    myParams.ReadJson(out dparams, out doffset);

                    Point[] intermPts = IncertRCP(startPt, mpDir, landingPts[ptInd], dparams, doffset);

                    if (intermPts.Length > 0)
                    {
                        intermediatepts.AddRange(intermPts);
                    }
                    else
                        theUI.NXMessageBox.Show("RCP Error", NXMessageBox.DialogType.Error, "Intermediate points not found");

                    createSplinePath(startPt, intermediatepts, landingPts[ptInd]);
                    intermediatepts.Clear();
                    multiPorts[i].SetBooleanUserAttribute("is_MP_to_Ground_done", -1, true, Update.Option.Now);
                }

            }
        }

        private static void createSplinePath(Point startPt, List<Point> intermediatepts, Point endpt)
        {
            NXOpen.Curve nullNXOpen_Curve = null;
            NXOpen.Routing.SplinePathBuilder splinePathBuilder1;
            splinePathBuilder1 = workpart.RouteManager.CreateSplinePathBuilder(nullNXOpen_Curve);

            NXOpen.Expression expression1;
            expression1 = splinePathBuilder1.BoundedCurvatureRadius;

            NXOpen.Expression expression2;
            expression2 = splinePathBuilder1.BoundedCurvatureRatio;

            NXOpen.Routing.PathStockBuilder pathStockBuilder1;
            pathStockBuilder1 = workpart.RouteManager.CreatePathStockBuilder();

            splinePathBuilder1.ShowSplineMinimumRadius = true;

            pathStockBuilder1.StockType = NXOpen.Routing.PathStockBuilder.AssignStockType.Stock;

            expression1.RightHandSide = "0";

            expression2.RightHandSide = "0";

            pathStockBuilder1.RectangularWidth.RightHandSide = "0";

            pathStockBuilder1.RectangularHeight.RightHandSide = "0";

            pathStockBuilder1.RectangularRotation.RightHandSide = "0";

            pathStockBuilder1.FlatOvalWidth.RightHandSide = "0";

            pathStockBuilder1.FlatOvalHeight.RightHandSide = "0";

            pathStockBuilder1.FlatOvalRotation.RightHandSide = "0";

            splinePathBuilder1.MinimumCheckingAllowableValue.RightHandSide = "0";

            splinePathBuilder1.MinimumCheckingAllowableRatio.RightHandSide = "0";

            splinePathBuilder1.SetDefaultPortExtensionLength(1.0);

            pathStockBuilder1.OverrideRotation(false);

            pathStockBuilder1.EnableDefaultOrientationAlignment(true);

            bool useboundedcurvature1;
            useboundedcurvature1 = splinePathBuilder1.BoundedCurvature;

            splinePathBuilder1.SetLockToSelectedFlag(true);

            splinePathBuilder1.SetAddPointsOnSubdivideFlag(true);

            splinePathBuilder1.SetCreateTangencyFlag(true);

            /*--------------------------------------------------------------------------------------------------*/
            Xform null_Xform = null;
            Point stPoint = workpart.Points.CreatePoint(startPt, null_Xform, SmartObject.UpdateOption.WithinModeling);
            startPt.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);

            int index1;
            index1 = splinePathBuilder1.AddDefiningPointToSpline(startPt, true);

            NXOpen.Point mPoint;
            for (int i = 0; i < intermediatepts.Count; i++)
            {
                mPoint = workpart.Points.CreatePoint(intermediatepts[i], null_Xform, SmartObject.UpdateOption.WithinModeling);
                mPoint.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);
                int index;
                index = splinePathBuilder1.AddDefiningPointToSpline(mPoint, true);
            }

            Point enPoint;
            enPoint = workpart.Points.CreatePoint(endpt, null_Xform, SmartObject.UpdateOption.WithinModeling);
            enPoint.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);

            int index2;
            index2 = splinePathBuilder1.AddDefiningPointToSpline(enPoint, true);
            /*--------------------------------------------------------------------------------------------------*/

            NXOpen.NXObject nXObject2;
            nXObject2 = splinePathBuilder1.Commit();

            NXOpen.NXObject[] objects1;
            objects1 = splinePathBuilder1.GetCommittedObjects();

            NXOpen.Curve curve1;
            curve1 = splinePathBuilder1.GetRouteSegment();

            NXOpen.Routing.ISegment[] segments1 = new NXOpen.Routing.ISegment[1];
            NXOpen.Routing.SplineSegment splineSegment1 = (NXOpen.Routing.SplineSegment)curve1;
            segments1[0] = splineSegment1;
            pathStockBuilder1.AssignStock(segments1);

            NXOpen.NXObject[] objects2 = new NXOpen.NXObject[1];
            objects2[0] = splineSegment1;
            workpart.RouteManager.LogConcurrent(objects2);

            NXOpen.Session.UndoMarkId id2;
            id2 = nxsession.GetNewestUndoMark(NXOpen.Session.MarkVisibility.AnyVisibility);

            nxsession.UpdateManager.DoAssemblyConstraintsUpdate(id2);

            splinePathBuilder1.SetDefaultPortExtensionLength(0.0);

            splinePathBuilder1.Destroy();

            pathStockBuilder1.Destroy();

            NXOpen.Session.UndoMarkId markId4;
            markId4 = nxsession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Routing: Run Concurrent Check");

            NXOpen.NXObject[] objects3 = new NXOpen.NXObject[0];
            NXOpen.Routing.DesignRuleViolation[] violations1;
            workpart.RouteManager.CheckDesignRules(NXOpen.Routing.DesignRuleViolationCollection.Mode.Concurrent, NXOpen.Routing.DesignRuleViolationCollection.Reason.CreatePath, objects3, out violations1);

            nxsession.DeleteUndoMark(markId4, "Routing: Run Concurrent Check");

            nxsession.DesignRuleManager.ClearConcurrent();
        }
        public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
        private static Point[] IncertRCP(Point startPt, Direction Dir, Point endPt, double[] dparams, double[] doffset, bool bvisibility = false)
        {
            workpart.Points.RemoveParameters(endPt);
            endPt.RemoveViewDependency();

            workpart.Points.RemoveParameters(startPt); //ARW
            startPt.RemoveViewDependency();//ARW

            Point[] outpts = new Point[dparams.Length];
            Dir.ProtectFromDelete();
            startPt.ProtectFromDelete();
            for (int i = 0; i < dparams.Length; i++)
            {
                double dtemp = dparams[i] / 100;
                string stemp = dtemp.ToString();

                Expression expression1 = workpart.Expressions.CreateSystemExpressionWithUnits(stemp, null);
                expression1.RightHandSide = stemp;
                Scalar scalar1 = workpart.Scalars.CreateScalarExpression(expression1, Scalar.DimensionalityType.Length, SmartObject.UpdateOption.WithinModeling);
                Point refPt = workpart.Points.CreatePoint(startPt, endPt, scalar1, SmartObject.UpdateOption.WithinModeling);

                stemp = doffset[i].ToString();
                Unit mmUnit = workpart.UnitCollection.FindObject("MilliMeter");
                Expression expression2 = workpart.Expressions.CreateSystemExpressionWithUnits(stemp, mmUnit);
                Scalar scalar2 = workpart.Scalars.CreateScalarExpression(expression2, Scalar.DimensionalityType.Length, SmartObject.UpdateOption.WithinModeling);
                Offset offset1 = workpart.Offsets.CreateOffset(Dir, scalar2, SmartObject.UpdateOption.WithinModeling);

                outpts[i] = workpart.Points.CreatePoint(offset1, refPt, SmartObject.UpdateOption.WithinModeling);
                workpart.Points.DeletePoint(refPt);

                if (bvisibility)
                    outpts[i].SetVisibility(SmartObject.VisibilityOption.Visible);
                else
                    outpts[i].SetVisibility(SmartObject.VisibilityOption.Invisible);

                //NXOpen.Features.Feature null_nxopen_features = null;
                //NXOpen.Features.PointFeatureBuilder ptFeatureBuilder = workpart.BaseFeatures.CreatePointFeatureBuilder(null_nxopen_features);
                //ptFeatureBuilder.Point = outpts[i];

                //NXObject nxObj = ptFeatureBuilder.Commit();
                //ptFeatureBuilder.Destroy();

            }
            Dir.ReleaseDeleteProtection();
            return outpts;
        }

        private static void closestPt(Point point, Point[] landingPts, out int index)
        //private static void closestPt(Point point, PointFeature[] landingPts, out int index)
        {
            index = -1;
            double minDist = 1E+07;
            //UFModl uFModl;
            double[] guess1 = { point.Coordinates.X, point.Coordinates.Y, point.Coordinates.Z };
            for (int i = 0; i < landingPts.Length; i++)
            {
                Point lndPt = (Point)landingPts[i];
                double[] guess2 = { lndPt.Coordinates.X, lndPt.Coordinates.Y, lndPt.Coordinates.Z };
                double[] pt_on_obj1 = new double[3];
                double[] pt_on_obj2 = new double[3];
                uFSession.Modl.AskMinimumDist(Tag.Null, Tag.Null, 1, guess1, 1, guess2, out double min, pt_on_obj1, pt_on_obj2);
                if (min < minDist )
                {
                    minDist = min;
                    index = i;
                }
            }
        }
    }
}
