using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : AbstractSingleton<Collectables>
{
    //la liste des  objets collectees, referencees par leur nom
    private HashSet<string> objectsOwned = new HashSet<string> ();

    //ajoute une nouvelle carte de collectee
    public void AddObject(string obj)
    {
        objectsOwned.Add(obj);
    }
    
    //renvoie true si la carte est collectee, false sinon
    public bool CheckObject(string obj)
    {
        return objectsOwned.Contains(obj);
    }

    //renvoie un array contenant tous les noms des objets collectees
    public string[] ArrayObjects()
    {
        string[] res = new string[objectsOwned.Count];
        objectsOwned.CopyTo(res);
        return res;
    }

    public void DeleteObject()
    {
        objectsOwned = new HashSet<string>();
    }

}
