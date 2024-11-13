// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Path : MonoBehaviour
// {
//     // List untuk menyimpan titik-titik jalur yang akan diikuti
//     public List<Transform> path = new List<Transform>();
//     // Warna dari garis yang akan digambar di editor
//     public Color rayColor = Color.white;

//     // Fungsi ini dijalankan setiap kali editor Unity melakukan refresh pada tampilan
//     void OnDrawGizmos()
//     {
//         // Menetapkan warna garis yang akan digambar
//         Gizmos.color = rayColor;

//         // Ambil semua objek anak (child) dari GameObject ini
//         Transform[] path_objs = GetComponentsInChildren<Transform>();
//         path.Clear();  // Kosongkan list path

//         // Simpan setiap transform (kecuali transform milik objek ini)
//         foreach (Transform path_obj in path_objs)
//         {
//             if (path_obj != transform)
//             {
//                 path.Add(path_obj);
//             }
//         }

//         // Gambarkan jalur dengan garis yang menghubungkan titik-titik
//         for (int i = 0; i < path.Count; i++)
//         {
//             Vector3 pos = path[i].position;
//             if (i > 0)
//             {
//                 // Gambarkan garis antara titik saat ini dan sebelumnya
//                 Vector3 prev = path[i - 1].position;
//                 Gizmos.DrawLine(prev, pos);
//             }
//             // Gambarkan lingkaran kecil di setiap titik jalur
//             Gizmos.DrawWireSphere(pos, 0.3f);
//         }
//     }
// }






























using UnityEngine;
using System.Collections.Generic;

public class Path : MonoBehaviour {
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;

    private void OnDrawGizmos() {
        foreach (Transform t in transform) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint){
        return null;
    }
}




















































