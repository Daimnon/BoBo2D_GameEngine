using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using Newtonsoft.Json;


namespace BoBo2D_Eyal_Gal
{
    public class SaveManager
    {
        //    SaveData _saveData = new SaveData();
        //    string _savePath = @"\BOBO3DSaveData.json";
        //    string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BoBo3DGal_Eyal";

        //    public bool CheckForJsonFile()//check if there is already a file or not
        //    {
        //        if (!Directory.Exists(_folderPath))
        //        {
        //            Directory.CreateDirectory(_folderPath);
        //            File.Create(_folderPath + _savePath).Close();
        //            return false;
        //        }
        //        else
        //        {
        //            if (!File.Exists(_folderPath + _savePath))
        //            {
        //                File.Create(_folderPath + _savePath).Close();
        //                return false;
        //            }
        //            else
        //            {
        //            }
        //        }
        //        return true;
        //    }
        //    public void DestroyJsonFile()//delete file
        //    {
        //        File.Delete(_folderPath + _savePath);
        //    }
        //    public void SaveJsonFile(SaveData saveData)//save from saveData to Json and transform to file
        //    {
        //        CheckForJsonFile();
        //        File.WriteAllText(_folderPath + _savePath, JsonConvert.SerializeObject(saveData, Formatting.Indented));
        //    }
        //    public SaveData LoadFromJson()//Load From File To String and afterward transform to saveData
        //    {
        //        string jsonString = File.ReadAllText(_folderPath + _savePath);
        //        SaveData saveData = JsonConvert.DeserializeObject<SaveData>(jsonString);
        //        return saveData;
        //    }
        //    public void LoadToSaveData()//save to SaveData Class
        //    {
        //        _saveData = LoadFromJson();
        //    }
    }
}

