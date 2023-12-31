// NX 12.0.0.27
// Journal created by Ajinkya on Wed Sep 28 23:05:42 2022 India Standard Time
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
    NXOpen.Session.UndoMarkId markId1;
    markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Make Work Part");
    
    NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)workPart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
    NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
    NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
    NXOpen.PartLoadStatus partLoadStatus1;
    theSession.Parts.SetWorkComponent(component3, NXOpen.PartCollection.RefsetOption.Entire, NXOpen.PartCollection.WorkComponentOption.Visible, out partLoadStatus1);
    
    workPart = theSession.Parts.Work; // C-1
    partLoadStatus1.Dispose();
    theSession.SetUndoMarkName(markId1, "Make Work Part");
    
    // ----------------------------------------------
    //   Menu: Information->Object...
    // ----------------------------------------------
    NXOpen.NXObject[] selectedObjects1 = new NXOpen.NXObject[1];
    NXOpen.Routing.FeaturePort featurePort1 = (NXOpen.Routing.FeaturePort)workPart.Features.FindObject("Port(2)");
    selectedObjects1[0] = featurePort1;
    theSession.Information.DisplayObjectsDetails(selectedObjects1);
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
