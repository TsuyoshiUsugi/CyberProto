using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.Json;

public class PlayerPrefsSaveService : ISaveService
{
    public bool Save<T>(string filename, T data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);

        try
        {
            PlayerPrefs.SetString(filename, jsonString);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool Load<T>(string filename, out T? data)
    {
        string jsonString = PlayerPrefs.GetString(filename);
        if (jsonString == null || jsonString == "")
        {
            //throw new InvalidOperationException("�Z�[�u����ĂȂ��Ⴕ���͂��̑��̃G���[");
            data = default;
            return false;
        }

        data =JsonSerializer.Deserialize<T>(jsonString);
        return true;
    }

}
