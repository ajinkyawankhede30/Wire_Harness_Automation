// NX 12.0.0.27
// Journal created by Ajinkya on Sat Oct  1 14:20:23 2022 India Standard Time
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
    
    NXOpen.Assemblies.Component nullNXOpen_Assemblies_Component = null;
    NXOpen.PartLoadStatus partLoadStatus1;
    theSession.Parts.SetWorkComponent(nullNXOpen_Assemblies_Component, NXOpen.PartCollection.RefsetOption.Entire, NXOpen.PartCollection.WorkComponentOption.Visible, out partLoadStatus1);
    
    workPart = theSession.Parts.Work; // MainAssembly
    partLoadStatus1.Dispose();
    theSession.SetUndoMarkName(markId1, "Make Work Part");
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
