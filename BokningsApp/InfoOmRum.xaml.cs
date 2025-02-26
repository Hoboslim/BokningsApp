namespace BokningsApp
{
    public partial class InfoOmRum : ContentPage
    {
        public InfoOmRum()
        {
            InitializeComponent();
        }

        // Hantera valet fr�n varje Picker
        private void OnRoomSelected(object sender, EventArgs e)
        {
            // H�mta det valda rummet f�r respektive Picker
            string roomInfo = "";

            if (sender == roomPickerTV)
            {
                roomInfo = GetRoomInfo(roomPickerTV.SelectedItem?.ToString());
            }
            else if (sender == roomPickerSmartBoard)
            {
                roomInfo = GetRoomInfo(roomPickerSmartBoard.SelectedItem?.ToString());
            }
            else if (sender == roomPickerGeneral)
            {
                roomInfo = GetRoomInfo(roomPickerGeneral.SelectedItem?.ToString());
            }

            // Visa informationen om rummet
            roomInfoLabel.Text = roomInfo;
        }

        // H�mta information f�r rummet
        private string GetRoomInfo(string selectedRoom)
        {
            return selectedRoom switch
            {
                "Fusion" => "Fusion - Detta rum har en TV och modern utrustning.",
                "Horizon" => "Horizon - Ett rum med h�ghastighetsinternet och projektor.",
                "Pinnacle" => "Pinnacle - En plats f�r kreativt arbete med SmartBoard.",
                "Synergy" => "Synergy - Ett rum med avancerad SmartBoard-teknologi.",
                "Nexus" => "Nexus - Ett rum f�r digitala m�ten.",
                "Elevate" => "Elevate - Ett rum f�r h�gt kreativa m�ten.",
                "Vertex" => "Vertex - Ett rum med panoramautsikt.",
                "Momentum" => "Momentum - Ett rum f�r snabb brainstorming.",
                _ => "V�lj ett rum f�r att visa information."
            };
        }
    }
}
