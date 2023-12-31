// NX 12.0.0.27
// Journal created by Ajinkya on Sat Sep 24 12:14:12 2022 India Standard Time
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
    //   Menu: Information->Object...
    // ----------------------------------------------
    NXOpen.NXObject[] selectedObjects1 = new NXOpen.NXObject[2];
    NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)workPart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
    NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
    NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-3 1");
    NXOpen.Routing.MultiPort multiPort1 = (NXOpen.Routing.MultiPort)component3.FindObject("PROTO#HANDLE R-603");
    selectedObjects1[0] = multiPort1;
    NXOpen.Assemblies.Component component4 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
    NXOpen.Routing.MultiPort multiPort2 = (NXOpen.Routing.MultiPort)component4.FindObject("PROTO#HANDLE R-1353");
    selectedObjects1[1] = multiPort2;
    theSession.Information.DisplayObjectsDetails(selectedObjects1);
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
