namespace BokningsApp
{
    public partial class InfoOmRum : ContentPage
    {
        public InfoOmRum()
        {
            InitializeComponent();
        }

        // Hantera valet från varje Picker
        private void OnRoomSelected(object sender, EventArgs e)
        {
            // Hämta det valda rummet för respektive Picker
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

        // Hämta information för rummet
        private string GetRoomInfo(string selectedRoom)
        {
            return selectedRoom switch
            {
                "Fusion" => "Fusion - Detta rum har en TV och modern utrustning.",
                "Horizon" => "Horizon - Ett rum med höghastighetsinternet och projektor.",
                "Pinnacle" => "Pinnacle - En plats för kreativt arbete med SmartBoard.",
                "Synergy" => "Synergy - Ett rum med avancerad SmartBoard-teknologi.",
                "Nexus" => "Nexus - Ett rum för digitala möten.",
                "Elevate" => "Elevate - Ett rum för högt kreativa möten.",
                "Vertex" => "Vertex - Ett rum med panoramautsikt.",
                "Momentum" => "Momentum - Ett rum för snabb brainstorming.",
                _ => "Välj ett rum för att visa information."
            };
        }
    }
}
