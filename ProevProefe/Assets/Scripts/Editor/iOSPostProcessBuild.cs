using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

// this class is required to add "NSMotionUsageDescription" key to info plist upon building, this determines the message sent to the user when requesting pedometer permissions

public class iOSPostProcessBuild : MonoBehaviour
{
    [PostProcessBuild]
    public static void ChangeXCodePlist(BuildTarget buildTarget, string pathToBuiltProject)
    {
        const string motionUsageDescription = "NSMotionUsageDescription";
        if(buildTarget == BuildTarget.iOS)
        {
            string plistPath = pathToBuiltProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);
            PlistElementDict root = plist.root;

            PlistElementArray arr = new PlistElementArray();
            arr.AddString(PermissionMessages.GetMessageInDeviceLanguage());
            root[motionUsageDescription] = arr;

            plist.WriteToFile(plistPath);
        }
    }

}
