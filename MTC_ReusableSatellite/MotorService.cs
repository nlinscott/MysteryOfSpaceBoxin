using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets
{
    public class MotorService : IMotorLeft, IMotorRight
    {
        public void TurnLeftOff()
        {
            Dictionary<string, string> formData = BuildFormDataSection("0");
            SendLeftMotorRequest(formData);
        }

        public void TurnLeftOn()
        {
            Dictionary<string, string> formData = BuildFormDataSection("80");
            SendLeftMotorRequest(formData);
        }

        public void TurnRightOn()
        {
            Dictionary<string, string> formData = BuildFormDataSection("80");
            SendRightMotorRequest(formData);
        }

        public void TurnRightOff()
        {
            Dictionary<string, string> formData = BuildFormDataSection("0");
            SendRightMotorRequest(formData);
        }

        private Dictionary<string, string> BuildFormDataSection(string data)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("arg", data);

            return dictionary;
        }

        private void SendLeftMotorRequest(Dictionary<string, string> formData)
        {
            UnityWebRequest www = UnityWebRequest.Post("https://api.particle.io/v1/devices/350045000c47343233323032/motorLeft?access_token=1b24b6dd08fbb1199ec1c8b689213e7c4a7cf580", formData);
            www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Post complete");
            }
        }

        private void SendRightMotorRequest(Dictionary<string, string> formData)
        {
            UnityWebRequest www = UnityWebRequest.Post("https://api.particle.io/v1/devices/350045000c47343233323032/motorRight?access_token=1b24b6dd08fbb1199ec1c8b689213e7c4a7cf580", formData);
            www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Post complete");
            }
        }
    }
}
