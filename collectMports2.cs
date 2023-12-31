// NX 12.0.0.27
// Journal created by Ajinkya on Tue Sep 27 22:15:30 2022 India Standard Time
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
    NXOpen.Point3d scaleAboutPoint1 = new NXOpen.Point3d(-79.964135020066365, 17.085612363289606, 0.0);
    NXOpen.Point3d viewCenter1 = new NXOpen.Point3d(79.964135020066365, -17.085612363289744, 0.0);
    displayPart.ModelingViews.WorkView.ZoomAboutPoint(1.25, scaleAboutPoint1, viewCenter1);
    
    // ----------------------------------------------
    //   Menu: Information->Object...
    // ----------------------------------------------
    NXOpen.NXObject[] selectedObjects1 = new NXOpen.NXObject[22];
    NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)displayPart.ComponentAssembly.RootComponent.FindObject("COMPONENT Device-1 1");
    NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)component1.FindObject("COMPONENT CF-1 1");
    NXOpen.Assemblies.Component component3 = (NXOpen.Assemblies.Component)component2.FindObject("COMPONENT C-1 1");
    NXOpen.Routing.MultiPort multiPort1 = (NXOpen.Routing.MultiPort)component3.FindObject("PROTO#HANDLE R-1353");
    selectedObjects1[0] = multiPort1;
    NXOpen.Face face1 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 6 {(25,5.4457279950768,18.6907380523604) BLOCK(1)}");
    selectedObjects1[1] = face1;
    NXOpen.Face face2 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 1 {(22.5,5.4457279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[2] = face2;
    NXOpen.Face face3 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 5 {(22.5,5.4457279950768,17.4407380523604) BLOCK(1)}");
    selectedObjects1[3] = face3;
    NXOpen.Face face4 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 2 {(22.5,4.1957279950768,18.6907380523604) BLOCK(1)}");
    selectedObjects1[4] = face4;
    NXOpen.Face face5 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 3 {(20,5.4457279950768,18.6907380523604) BLOCK(1)}");
    selectedObjects1[5] = face5;
    NXOpen.Face face6 = (NXOpen.Face)component3.FindObject("PROTO#.Features|BLOCK(1)|FACE 4 {(22.5,6.6957279950768,18.6907380523604) BLOCK(1)}");
    selectedObjects1[6] = face6;
    NXOpen.Body body1 = (NXOpen.Body)component3.FindObject("PROTO#.Bodies|BLOCK(1)");
    selectedObjects1[7] = body1;
    NXOpen.Edge edge1 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 1 * 2 {(25,4.1957279950768,19.9407380523604)(22.5,4.1957279950768,19.9407380523604)(20,4.1957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[8] = edge1;
    NXOpen.Edge edge2 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 1 * 3 {(20,4.1957279950768,19.9407380523604)(20,5.4457279950768,19.9407380523604)(20,6.6957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[9] = edge2;
    NXOpen.Edge edge3 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 1 * 4 {(20,6.6957279950768,19.9407380523604)(22.5,6.6957279950768,19.9407380523604)(25,6.6957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[10] = edge3;
    NXOpen.Edge edge4 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 1 * 6 {(25,6.6957279950768,19.9407380523604)(25,5.4457279950768,19.9407380523604)(25,4.1957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[11] = edge4;
    NXOpen.Edge edge5 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 2 * 3 {(20,4.1957279950768,17.4407380523604)(20,4.1957279950768,18.6907380523604)(20,4.1957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[12] = edge5;
    NXOpen.Edge edge6 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 3 * 4 {(20,6.6957279950768,17.4407380523604)(20,6.6957279950768,18.6907380523604)(20,6.6957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[13] = edge6;
    NXOpen.Edge edge7 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 4 * 6 {(25,6.6957279950768,17.4407380523604)(25,6.6957279950768,18.6907380523604)(25,6.6957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[14] = edge7;
    NXOpen.Edge edge8 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 2 * 6 {(25,4.1957279950768,17.4407380523604)(25,4.1957279950768,18.6907380523604)(25,4.1957279950768,19.9407380523604) BLOCK(1)}");
    selectedObjects1[15] = edge8;
    NXOpen.Edge edge9 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 5 * 6 {(25,4.1957279950768,17.4407380523604)(25,5.4457279950768,17.4407380523604)(25,6.6957279950768,17.4407380523604) BLOCK(1)}");
    selectedObjects1[16] = edge9;
    NXOpen.Edge edge10 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 4 * 5 {(25,6.6957279950768,17.4407380523604)(22.5,6.6957279950768,17.4407380523604)(20,6.6957279950768,17.4407380523604) BLOCK(1)}");
    selectedObjects1[17] = edge10;
    NXOpen.Edge edge11 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 3 * 5 {(20,6.6957279950768,17.4407380523604)(20,5.4457279950768,17.4407380523604)(20,4.1957279950768,17.4407380523604) BLOCK(1)}");
    selectedObjects1[18] = edge11;
    NXOpen.Edge edge12 = (NXOpen.Edge)component3.FindObject("PROTO#.Features|BLOCK(1)|EDGE * 2 * 5 {(20,4.1957279950768,17.4407380523604)(22.5,4.1957279950768,17.4407380523604)(25,4.1957279950768,17.4407380523604) BLOCK(1)}");
    selectedObjects1[19] = edge12;
    NXOpen.Routing.TerminalPort terminalPort1 = (NXOpen.Routing.TerminalPort)component3.FindObject("PROTO#HANDLE R-1358");
    selectedObjects1[20] = terminalPort1;
    NXOpen.Features.DatumCsys datumCsys1 = (NXOpen.Features.DatumCsys)workPart.Features.FindObject("DATUM_CSYS(0)");
    selectedObjects1[21] = datumCsys1;
    theSession.Information.DisplayObjectsDetails(selectedObjects1);
    
    // ----------------------------------------------
    //   Menu: Refresh
    // ----------------------------------------------
    displayPart.Views.Refresh();
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
