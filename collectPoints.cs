// NX 12.0.0.27
// Journal created by Ajinkya on Sat Sep 24 15:20:57 2022 India Standard Time
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
    NXOpen.Point3d scaleAboutPoint1 = new NXOpen.Point3d(-10.317432522671442, -2.4695982102139253, 0.0);
    NXOpen.Point3d viewCenter1 = new NXOpen.Point3d(10.317432522671377, 2.4695982102138765, 0.0);
    workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint1, viewCenter1);
    
    NXOpen.Point3d scaleAboutPoint2 = new NXOpen.Point3d(-12.896790653339288, -3.0869977627674028, 0.0);
    NXOpen.Point3d viewCenter2 = new NXOpen.Point3d(12.896790653339254, 3.0869977627673459, 0.0);
    workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint2, viewCenter2);
    
    NXOpen.Point3d scaleAboutPoint3 = new NXOpen.Point3d(-16.635487943802005, -4.2017469548778461, 0.0);
    NXOpen.Point3d viewCenter3 = new NXOpen.Point3d(16.635487943801962, 4.2017469548777902, 0.0);
    workPart.ModelingViews.WorkView.ZoomAboutPoint(0.80000000000000004, scaleAboutPoint3, viewCenter3);
    
    // ----------------------------------------------
    //   Menu: Edit->Properties...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId1;
    markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    NXOpen.NXObject[] objects1 = new NXOpen.NXObject[2];
    NXOpen.Features.PointFeature pointFeature1 = (NXOpen.Features.PointFeature)workPart.Features.FindObject("POINT(3)");
    NXOpen.Point point1 = (NXOpen.Point)pointFeature1.FindObject("POINT 1");
    objects1[0] = point1;
    NXOpen.Features.PointFeature pointFeature2 = (NXOpen.Features.PointFeature)workPart.Features.FindObject("POINT(2)");
    NXOpen.Point point2 = (NXOpen.Point)pointFeature2.FindObject("POINT 1");
    objects1[1] = point2;
    NXOpen.AttributePropertiesBuilder attributePropertiesBuilder1;
    attributePropertiesBuilder1 = theSession.AttributeManager.CreateAttributePropertiesBuilder(workPart, objects1, NXOpen.AttributePropertiesBuilder.OperationType.None);
    
    attributePropertiesBuilder1.IsArray = false;
    
    attributePropertiesBuilder1.IsArray = false;
    
    attributePropertiesBuilder1.IsArray = false;
    
    attributePropertiesBuilder1.DataType = NXOpen.AttributePropertiesBaseBuilder.DataTypeOptions.String;
    
    attributePropertiesBuilder1.Units = "MilliMeter";
    
    NXOpen.NXObject[] objects2 = new NXOpen.NXObject[2];
    objects2[0] = point1;
    objects2[1] = point2;
    NXOpen.ObjectGeneralPropertiesBuilder objectGeneralPropertiesBuilder1;
    objectGeneralPropertiesBuilder1 = workPart.PropertiesManager.CreateObjectGeneralPropertiesBuilder(objects2);
    
    NXOpen.SelectNXObjectList selectNXObjectList1;
    selectNXObjectList1 = objectGeneralPropertiesBuilder1.SelectedObjects;
    
    objectGeneralPropertiesBuilder1.NameLocationSpecified = false;
    
    objectGeneralPropertiesBuilder1.Index = 1;
    
    NXOpen.NXObject[] objects3 = new NXOpen.NXObject[2];
    objects3[0] = point2;
    objects3[1] = point1;
    attributePropertiesBuilder1.SetAttributeObjects(objects3);
    
    attributePropertiesBuilder1.Units = "MilliMeter";
    
    theSession.SetUndoMarkName(markId1, "Point Properties Dialog");
    
    attributePropertiesBuilder1.DateValue.DateItem.Day = NXOpen.DateItemBuilder.DayOfMonth.Day24;
    
    attributePropertiesBuilder1.DateValue.DateItem.Month = NXOpen.DateItemBuilder.MonthOfYear.Sep;
    
    attributePropertiesBuilder1.DateValue.DateItem.Year = "2022";
    
    attributePropertiesBuilder1.DateValue.DateItem.Time = "00:00:00";
    
    NXOpen.SelectNXObjectList selectNXObjectList2;
    selectNXObjectList2 = objectGeneralPropertiesBuilder1.SelectedObjects;
    
    NXOpen.NXObject[] objects4 = new NXOpen.NXObject[2];
    objects4[0] = pointFeature1;
    objects4[1] = pointFeature2;
    attributePropertiesBuilder1.SetAttributeObjects(objects4);
    
    attributePropertiesBuilder1.Units = "MilliMeter";
    
    NXOpen.Session.UndoMarkId markId2;
    markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Point Properties");
    
    theSession.DeleteUndoMark(markId2, null);
    
    NXOpen.Session.UndoMarkId markId3;
    markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Point Properties");
    
    NXOpen.Session.UndoMarkId markId4;
    markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Update Attribute Properties");
    
    int nErrs1;
    nErrs1 = theSession.UpdateManager.DoUpdate(markId4);
    
    NXOpen.NXObject nXObject1;
    nXObject1 = objectGeneralPropertiesBuilder1.Commit();
    
    NXOpen.Session.UndoMarkId id1;
    id1 = theSession.GetNewestUndoMark(NXOpen.Session.MarkVisibility.Visible);
    
    int nErrs2;
    nErrs2 = theSession.UpdateManager.DoUpdate(id1);
    
    theSession.DeleteUndoMark(markId3, null);
    
    theSession.SetUndoMarkName(markId1, "Point Properties");
    
    attributePropertiesBuilder1.Destroy();
    
    objectGeneralPropertiesBuilder1.Destroy();
    
    theSession.DeleteUndoMark(id1, null);
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
