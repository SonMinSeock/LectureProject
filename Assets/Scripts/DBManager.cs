using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string id;

    public static bool LoggedIn { get { return id != null; } }

    public static void LogOut() {
        id = null;
    }
}
