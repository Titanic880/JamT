using System.Text.Json;

namespace MacroUtil {
    internal class SaveData {
        private static readonly string AppDataPath = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\{Application.ProductName}\\";
        private const string DefaultFile = "SaveFile";
        private string CurrentFilenPath = AppDataPath + DefaultFile;


        #region Public Methods
        public bool LoadSave() {
            if (File.Exists(CurrentFilenPath) is false) {
                return false;
            }

            //Get the altered file location (if there is one)
            string location = GetLocation();
            if(location != "") {
                CurrentFilenPath = location;
            }

            //Grab save from location
            SaveData? data;
            try {
                data =  JsonSerializer.Deserialize<SaveData>(CurrentFilenPath);
                if(data is null) {
                    return false;
                }
            } catch {
                return false;
            }

            //Load save onto current object
            LoadToCurrentObject(data);
            return true;
        }
        
        public virtual bool Save() {
            if (File.Exists(CurrentFilenPath) is false) {
                File.Create(CurrentFilenPath).Close();
            }


            return true;
        }
        public virtual void ResetToDefaults() {
            CurrentFilenPath = AppDataPath + DefaultFile;
        }
        public void ResetSaveLocationToDefault() {
            CurrentFilenPath = AppDataPath + DefaultFile;
            File.WriteAllText(CurrentFilenPath,"");
        }
        public void SetSaveLocation(string NewLocation) {
            LocationObject locobj = new() {
                Location = NewLocation
            };
            File.WriteAllText(DefaultFile, JsonSerializer.Serialize(locobj));
            CurrentFilenPath = NewLocation;
        }
        #endregion Public Methods
        protected virtual void LoadToCurrentObject(SaveData SaveInfo) {

        }

        #region Private Methods
        private string GetLocation() {
            try {
                return JsonSerializer.Deserialize<LocationObject>(CurrentFilenPath)!.Location;
            } catch {
                return "";
            }
        }
        #endregion Private Methods
    }
    class LocationObject {
        public string Location { get; set; } = "";
    }
}
