//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Cosmos.IL2CPU.Plugs;
//using System.IO;
//using Cosmos.System.FileSystem;
//using Cosmos.System.FileSystem.VFS;

//namespace Cosmos.System.Plugs.System.IO
//{
//    [Plug(Target = typeof(FileInfo))]
//    [PlugField(FieldId = "$$Storage$$", FieldType = typeof(Cosmos.System.FileSystem.Listing.File))]
//    public static class FileInfoImpl
//    {
//        //[PlugMethod(Signature = "System_Void__System_IO_FileInfo__ctor_System_String_")]
//        public static void Ctor(FileInfo aThis, [FieldAccess(Name = "$$Storage$$")] ref Cosmos.System.FileSystem.Listing.Directory aStorage, string aFile)
//        {
//            //Determine if aFile is relative or absolute
//            string xFile;
//            if (aFile.IsRelativePath())
//                xFile = Directory.GetCurrentDirectory() + aFile;
//            else
//                xFile = aFile;

//            var xEntry = VFSManager.GetDirectory(xFile);

//            if (xEntry is Cosmos.System.FileSystem.Listing.Directory)
//            {
//                aStorage = xEntry as Cosmos.System.FileSystem.Listing.Directory;
//            }
//        }

//        public static string get_Name([FieldAccess(Name = "$$Storage$$")] ref Cosmos.System.FileSystem.Listing.File aStorage)
//        {
//            return "Filename" + aStorage.Name;
//        }

//        public static bool get_Exists([FieldAccess(Name = "$$Storage$$")] ref Cosmos.System.FileSystem.Listing.File aStorage)
//        {
//            return VFSManager.FileExists(aStorage.Name);
//        }

//        public static string ToString(FileInfo aThis)
//        {
//            return "FileInfo.ToString() not yet implemented!";
//        }
//    }
//}
