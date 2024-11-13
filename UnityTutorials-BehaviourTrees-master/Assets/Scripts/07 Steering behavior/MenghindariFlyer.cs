using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenghindariFlyer : MonoBehaviour
{
    public float targetVelocity = 10.0f;   // Kecepatan gerak objek
    public int numberOfRays = 17;          // Jumlah ray yang akan ditembakkan
    public float angle = 99;               // Sudut penyebaran ray
    public float rayRange = 2;             // Jarak maksimum ray


    void Update()
    {    
        var deltaPosition = Vector3.zero; 
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;

            var ray = new Ray(this.transform.position, direction);
            RaycastHit hitInfo;

            // Memeriksa apakah ray mengenai rintangan
            if (Physics.Raycast(ray, out hitInfo, rayRange))
            {
                // Jika terkena rintangan, kurangi gerakan ke arah tersebut (menghindari rintangan)
                deltaPosition -= (1.0f / numberOfRays) * targetVelocity * direction * (rayRange - hitInfo.distance) / rayRange;
            }
            else
            {
                // Jika tidak terkena rintangan, bergerak normal ke arah tersebut
                deltaPosition += (1.0f / numberOfRays) * targetVelocity * direction;
            }
        }

        // Memindahkan objek berdasarkan deltaPosition
        this.transform.position += deltaPosition * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;

            // Visualisasi ray dengan panjang sesuai jarak maksimum
            Gizmos.DrawRay(this.transform.position, direction * rayRange);
        }
    }
}






















// public class MenghindariFlyer : MonoBehaviour
// {
//     public float targetVelocity = 10.0f;   // Movement speed of the object
//     public int numberOfRays = 17;          // Number of rays to cast
//     public float angle = 99;               // Spread angle for the rays
//     public float rayRange = 2;             // Maximum range of the rays

//     // Update is called once per frame
//     void Update()
//     {    
//         var deltaPosition = Vector3.zero; 
//         for (int i = 0; i < numberOfRays; ++i)
//         {
//             var rotation = this.transform.rotation;
//             var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
//             var direction = rotation * rotationMod * Vector3.forward;

//             var ray = new Ray(this.transform.position, direction);
//             RaycastHit hitInfo;

//             // Check if the ray hits an obstacle
//             if (Physics.Raycast(ray, out hitInfo, rayRange))
//             {
//                 // If hit, reduce movement in this direction by a fraction (avoiding the obstacle)
//                 deltaPosition -= (1.0f / numberOfRays) * targetVelocity * direction * (rayRange - hitInfo.distance) / rayRange;
//             }
//             else
//             {
//                 // If no hit, move in this direction normally
//                 deltaPosition += (1.0f / numberOfRays) * targetVelocity * direction;
//             }
//         }

//         // Move the object based on deltaPosition
//         this.transform.position += deltaPosition * Time.deltaTime;
//     }

//     // Visualize the rays in the editor for debugging
//     void OnDrawGizmos()
//     {
//         for (int i = 0; i < numberOfRays; ++i)
//         {
//             var rotation = this.transform.rotation;
//             var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
//             var direction = rotation * rotationMod * Vector3.forward;

//             // Visualize the rays with their range
//             Gizmos.DrawRay(this.transform.position, direction * rayRange);
//         }
//     }
// }
