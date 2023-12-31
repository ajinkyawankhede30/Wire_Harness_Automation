// NX 12.0.0.27
// Journal created by Ajinkya on Thu Sep 22 20:34:49 2022 India Standard Time
//
using System;
using NXOpen;

public class NXJournal
{
  public static void Main(string[] args)
  {
    NXOpen.Session theSession = NXOpen.Session.GetSession();
    NXOpen.Part workPart = theSession.Parts.Work;
    NXOpen.Part displayPart = theSession.Parts.Display;
    // ----------------------------------------------
    //   Menu: Insert->Routing Path->Spline Path...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId1;
    markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    bool delayed1;
    delayed1 = theSession.UpdateManager.AssemblyConstraintsDelay;
    
    NXOpen.Curve nullNXOpen_Curve = null;
    NXOpen.Routing.SplinePathBuilder splinePathBuilder1;
    splinePathBuilder1 = workPart.RouteManager.CreateSplinePathBuilder(nullNXOpen_Curve);
    
    NXOpen.Expression expression1;
    expression1 = splinePathBuilder1.BoundedCurvatureRadius;
    
    NXOpen.Expression expression2;
    expression2 = splinePathBuilder1.BoundedCurvatureRatio;
    
    NXOpen.Routing.PathStockBuilder pathStockBuilder1;
    pathStockBuilder1 = workPart.RouteManager.CreatePathStockBuilder();
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType1;
    stockType1 = pathStockBuilder1.StockType;
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType2;
    stockType2 = pathStockBuilder1.StockType;
    
    NXOpen.Point3d coordinates1 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point1;
    point1 = workPart.Points.CreatePoint(coordinates1);
    
    NXOpen.Point3d coordinates2 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point2;
    point2 = workPart.Points.CreatePoint(coordinates2);
    
    workPart.Points.DeletePoint(point1);
    
    workPart.Points.DeletePoint(point2);
    
    splinePathBuilder1.ShowSplineMinimumRadius = true;
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType3;
    stockType3 = pathStockBuilder1.StockType;
    
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
    
    NXOpen.Point3d coordinates3 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point3;
    point3 = workPart.Points.CreatePoint(coordinates3);
    
    NXOpen.Point3d coordinates4 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point4;
    point4 = workPart.Points.CreatePoint(coordinates4);
    
    workPart.Points.DeletePoint(point3);
    
    workPart.Points.DeletePoint(point4);
    
    splinePathBuilder1.SetDefaultPortExtensionLength(1.0);
    
    theSession.SetUndoMarkName(markId1, "Spline Path Dialog");
    
    NXOpen.Unit unit1;
    unit1 = splinePathBuilder1.MinimumCheckingAllowableValue.Units;
    
    NXOpen.Expression expression3;
    expression3 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    pathStockBuilder1.OverrideRotation(false);
    
    pathStockBuilder1.EnableDefaultOrientationAlignment(true);
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType4;
    stockType4 = pathStockBuilder1.StockType;
    
    NXOpen.Direction direction1;
    direction1 = workPart.RouteManager.DownDirection;
    
    NXOpen.Expression expression4;
    expression4 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    bool useboundedcurvature1;
    useboundedcurvature1 = splinePathBuilder1.BoundedCurvature;
    
    NXOpen.Routing.SplinePathBuilder.SplinePathRadiusSource source1;
    source1 = splinePathBuilder1.RadiusSource;
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType5;
    stockType5 = pathStockBuilder1.StockType;
    
    splinePathBuilder1.SetLockToSelectedFlag(true);
    
    splinePathBuilder1.SetAddPointsOnSubdivideFlag(true);
    
    splinePathBuilder1.SetCreateTangencyFlag(true);
    
    bool useboundedcurvature2;
    useboundedcurvature2 = splinePathBuilder1.BoundedCurvature;
    
    NXOpen.Expression expression5;
    expression5 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Expression expression6;
    expression6 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Scalar scalar1;
    scalar1 = workPart.Scalars.CreateScalar(0.0, NXOpen.Scalar.DimensionalityType.Length, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)workPart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
    NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
    NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
    NXOpen.Routing.MultiPort multiPort1 = (NXOpen.Routing.MultiPort)component3.FindObject("PROTO#ENTITY 221 2 1");
    NXOpen.Point point5;
    point5 = workPart.Points.CreatePointOnPortExtractAlign(NXOpen.SmartObject.UpdateOption.WithinModeling, multiPort1, scalar1);
    
    NXOpen.Scalar scalar2;
    scalar2 = workPart.Scalars.CreateScalar(0.0, NXOpen.Scalar.DimensionalityType.Length, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Point point6;
    point6 = workPart.Points.CreatePointOnPortExtractAlign(NXOpen.SmartObject.UpdateOption.WithinModeling, multiPort1, scalar2);
    
    point6.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);
    
    int index1;
    index1 = splinePathBuilder1.AddDefiningPointToSpline(point6, true);
    
    NXOpen.Point3d origin1 = new NXOpen.Point3d(24.999999999999996, 5.4457279950768296, 18.690738052360398);
    NXOpen.Vector3d vector1 = new NXOpen.Vector3d(1.0, 0.0, 0.0);
    NXOpen.Direction direction2;
    direction2 = workPart.Directions.CreateDirection(origin1, vector1, NXOpen.SmartObject.UpdateOption.AfterModeling);
    
    NXOpen.Expression expression7;
    expression7 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Point3d coordinates5 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point7;
    point7 = workPart.Points.CreatePoint(coordinates5);
    
    NXOpen.Point3d coordinates6 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point8;
    point8 = workPart.Points.CreatePoint(coordinates6);
    
    workPart.Points.DeletePoint(point7);
    
    workPart.Points.DeletePoint(point8);
    
    NXOpen.Expression expression8;
    expression8 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    int nErrs1;
    nErrs1 = theSession.UpdateManager.AddToDeleteList(point5);
    
    NXOpen.Point3d origin2 = new NXOpen.Point3d(24.999999999999996, 5.4457279950768296, 18.690738052360398);
    direction2.Origin = origin2;
    
    NXOpen.Vector3d vector2 = new NXOpen.Vector3d(1.0, 0.0, 0.0);
    direction2.Vector = vector2;
    
    splinePathBuilder1.SetStockBoundedDiameter(0.0);
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType6;
    stockType6 = pathStockBuilder1.StockType;
    
    NXOpen.Point3d coordinates7 = new NXOpen.Point3d(31.920752180257281, 40.476883170361511, 0.0);
    NXOpen.Point point9;
    point9 = workPart.Points.CreatePoint(coordinates7);
    
    NXOpen.Expression expression9;
    expression9 = workPart.Expressions.CreateSystemExpressionWithUnits("p45_x=31.9207521802573", unit1);
    
    NXOpen.Scalar scalar3;
    scalar3 = workPart.Scalars.CreateScalarExpression(expression9, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Expression expression10;
    expression10 = workPart.Expressions.CreateSystemExpressionWithUnits("p46_y=40.4768831703615", unit1);
    
    NXOpen.Scalar scalar4;
    scalar4 = workPart.Scalars.CreateScalarExpression(expression10, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Expression expression11;
    expression11 = workPart.Expressions.CreateSystemExpressionWithUnits("p47_z=0", unit1);
    
    NXOpen.Scalar scalar5;
    scalar5 = workPart.Scalars.CreateScalarExpression(expression11, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Point point10;
    point10 = workPart.Points.CreatePoint(scalar3, scalar4, scalar5, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    point10.RemoveViewDependency();
    
    NXOpen.Point3d coordinates8 = new NXOpen.Point3d(31.920752180257281, 40.476883170361511, 15.559822735563209);
    NXOpen.Point point11;
    point11 = workPart.Points.CreatePoint(coordinates8);
    
    int nErrs2;
    nErrs2 = theSession.UpdateManager.AddToDeleteList(point9);
    
    point11.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);
    
    int index2;
    index2 = splinePathBuilder1.AddDefiningPointToSpline(point11, true);
    
    NXOpen.Point3d coordinates9 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point12;
    point12 = workPart.Points.CreatePoint(coordinates9);
    
    NXOpen.Point3d coordinates10 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point13;
    point13 = workPart.Points.CreatePoint(coordinates10);
    
    workPart.Points.DeletePoint(point12);
    
    workPart.Points.DeletePoint(point13);
    
    NXOpen.Expression expression12;
    expression12 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Point3d origin3 = new NXOpen.Point3d(24.999999999999996, 5.4457279950768296, 18.690738052360398);
    direction2.Origin = origin3;
    
    NXOpen.Vector3d vector3 = new NXOpen.Vector3d(1.0, 0.0, 0.0);
    direction2.Vector = vector3;
    
    splinePathBuilder1.SetStockBoundedDiameter(0.0);
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType7;
    stockType7 = pathStockBuilder1.StockType;
    
    NXOpen.Point3d coordinates11 = new NXOpen.Point3d(32.793861283340036, 40.476883170361511, 0.0);
    NXOpen.Point point14;
    point14 = workPart.Points.CreatePoint(coordinates11);
    
    NXOpen.Expression expression13;
    expression13 = workPart.Expressions.CreateSystemExpressionWithUnits("p49_x=32.79386128334", unit1);
    
    NXOpen.Scalar scalar6;
    scalar6 = workPart.Scalars.CreateScalarExpression(expression13, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Expression expression14;
    expression14 = workPart.Expressions.CreateSystemExpressionWithUnits("p50_y=40.4768831703615", unit1);
    
    NXOpen.Scalar scalar7;
    scalar7 = workPart.Scalars.CreateScalarExpression(expression14, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Expression expression15;
    expression15 = workPart.Expressions.CreateSystemExpressionWithUnits("p51_z=0", unit1);
    
    NXOpen.Scalar scalar8;
    scalar8 = workPart.Scalars.CreateScalarExpression(expression15, NXOpen.Scalar.DimensionalityType.None, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.Point point15;
    point15 = workPart.Points.CreatePoint(scalar6, scalar7, scalar8, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    point15.RemoveViewDependency();
    
    NXOpen.Point3d coordinates12 = new NXOpen.Point3d(32.793861283340036, 40.476883170361511, 10.866861306493414);
    NXOpen.Point point16;
    point16 = workPart.Points.CreatePoint(coordinates12);
    
    int nErrs3;
    nErrs3 = theSession.UpdateManager.AddToDeleteList(point14);
    
    point16.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);
    
    int index3;
    index3 = splinePathBuilder1.AddDefiningPointToSpline(point16, true);
    
    NXOpen.Point3d coordinates13 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point17;
    point17 = workPart.Points.CreatePoint(coordinates13);
    
    NXOpen.Point3d coordinates14 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point18;
    point18 = workPart.Points.CreatePoint(coordinates14);
    
    workPart.Points.DeletePoint(point17);
    
    workPart.Points.DeletePoint(point18);
    
    NXOpen.Expression expression16;
    expression16 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Point3d origin4 = new NXOpen.Point3d(24.999999999999996, 5.4457279950768296, 18.690738052360398);
    direction2.Origin = origin4;
    
    NXOpen.Vector3d vector4 = new NXOpen.Vector3d(1.0, 0.0, 0.0);
    direction2.Vector = vector4;
    
    splinePathBuilder1.SetStockBoundedDiameter(0.0);
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType8;
    stockType8 = pathStockBuilder1.StockType;
    
    NXOpen.Routing.ControlPoint controlPoint1 = (NXOpen.Routing.ControlPoint)workPart.FindObject("ENTITY 220 4 1");
    NXOpen.Xform nullNXOpen_Xform = null;
    NXOpen.Point point19;
    point19 = workPart.Points.CreatePoint(controlPoint1, nullNXOpen_Xform, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    NXOpen.NXObject nXObject1;
    NXOpen.Xform xform1;
    xform1 = workPart.Xforms.CreateExtractXform(controlPoint1, NXOpen.SmartObject.UpdateOption.WithinModeling, false, out nXObject1);
    
    NXOpen.Routing.ControlPoint controlPoint2 = (NXOpen.Routing.ControlPoint)nXObject1;
    NXOpen.Point point20;
    point20 = workPart.Points.CreatePoint(controlPoint2, nullNXOpen_Xform, NXOpen.SmartObject.UpdateOption.WithinModeling);
    
    point20.SetUserAttribute("STOCK_OFFSET_POINT_METHOD", -1, 0, NXOpen.Update.Option.Later);
    
    int index4;
    index4 = splinePathBuilder1.AddDefiningPointToSpline(point20, true);
    
    NXOpen.Point3d coordinates15 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point21;
    point21 = workPart.Points.CreatePoint(coordinates15);
    
    NXOpen.Point3d coordinates16 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    NXOpen.Point point22;
    point22 = workPart.Points.CreatePoint(coordinates16);
    
    workPart.Points.DeletePoint(point21);
    
    workPart.Points.DeletePoint(point22);
    
    NXOpen.Expression expression17;
    expression17 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    int nErrs4;
    nErrs4 = theSession.UpdateManager.AddToDeleteList(point19);
    
    NXOpen.Point3d origin5 = new NXOpen.Point3d(24.999999999999996, 5.4457279950768296, 18.690738052360398);
    direction2.Origin = origin5;
    
    NXOpen.Vector3d vector5 = new NXOpen.Vector3d(1.0, 0.0, 0.0);
    direction2.Vector = vector5;
    
    splinePathBuilder1.SetStockBoundedDiameter(0.0);
    
    NXOpen.Routing.PathStockBuilder.AssignStockType stockType9;
    stockType9 = pathStockBuilder1.StockType;
    
    NXOpen.Session.UndoMarkId markId2;
    markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Spline Path");
    
    theSession.DeleteUndoMark(markId2, null);
    
    NXOpen.Session.UndoMarkId markId3;
    markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Spline Path");
    
    NXOpen.Session.UndoMarkId id1;
    id1 = theSession.GetNewestUndoMark(NXOpen.Session.MarkVisibility.AnyVisibility);
    
    string markName1;
    markName1 = theSession.GetUndoMarkName(id1);
    
    theSession.SetUndoMarkVisibility(id1, markName1, NXOpen.Session.MarkVisibility.Visible);
    
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
    workPart.RouteManager.LogConcurrent(objects2);
    
    NXOpen.NXObject nXObject3;
    nXObject3 = splinePathBuilder1.Commit();
    
    theSession.DeleteUndoMark(id1, null);
    
    theSession.SetUndoMarkName(markId1, markName1);
    
    NXOpen.Session.UndoMarkId id2;
    id2 = theSession.GetNewestUndoMark(NXOpen.Session.MarkVisibility.AnyVisibility);
    
    theSession.UpdateManager.DoAssemblyConstraintsUpdate(id2);
    
    splinePathBuilder1.SetDefaultPortExtensionLength(0.0);
    
    splinePathBuilder1.Destroy();
    
    pathStockBuilder1.Destroy();
    
    workPart.Expressions.Delete(expression4);
    
    workPart.Expressions.Delete(expression3);
    
    workPart.Expressions.Delete(expression6);
    
    workPart.Expressions.Delete(expression5);
    
    workPart.Expressions.Delete(expression7);
    
    workPart.Expressions.Delete(expression8);
    
    workPart.Expressions.Delete(expression12);
    
    workPart.Expressions.Delete(expression16);
    
    workPart.Expressions.Delete(expression17);
    
    NXOpen.Session.UndoMarkId markId4;
    markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Routing: Run Concurrent Check");
    
    NXOpen.NXObject[] objects3 = new NXOpen.NXObject[0];
    NXOpen.Routing.DesignRuleViolation[] violations1;
    workPart.RouteManager.CheckDesignRules(NXOpen.Routing.DesignRuleViolationCollection.Mode.Concurrent, NXOpen.Routing.DesignRuleViolationCollection.Reason.CreatePath, objects3, out violations1);
    
    theSession.DeleteUndoMark(markId4, "Routing: Run Concurrent Check");
    
    theSession.DesignRuleManager.ClearConcurrent();
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
