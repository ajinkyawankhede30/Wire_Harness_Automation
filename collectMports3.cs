// NX 12.0.0.27
// Journal created by Ajinkya on Wed Sep 28 22:10:35 2022 India Standard Time
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
    NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)displayPart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
    NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
    NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
    NXOpen.Routing.MultiPort multiPort1 = (NXOpen.Routing.MultiPort)component3.FindObject("PROTO#HANDLE R-1353");
    selectedObjects1[0] = multiPort1;
    NXOpen.Routing.TerminalPort terminalPort1 = (NXOpen.Routing.TerminalPort)component3.FindObject("PROTO#HANDLE R-1358");
    selectedObjects1[1] = terminalPort1;
    theSession.Information.DisplayObjectsDetails(selectedObjects1);
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
