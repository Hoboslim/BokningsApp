using System.Collections.Generic;
using MongoDB;
using BokningsApp.Data;
using BokningsApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace BokningsApp.Admin;

public partial class EditRooms : ContentPage
{
    private Dictionary<string, List<string>> roomData = new();

    public EditRooms()
    {
        InitializeComponent();
        LoadRoomsFromDB();

    }
    private async void LoadRoomsFromDB()
    {
        var roomCollection = DB.GetRoomsCollection();
        var rooms = await roomCollection.Find(FilterDefinition<Models.Rooms>.Empty).ToListAsync();

        roomData = rooms
             .Where(r => !string.IsNullOrEmpty(r.RoomType) && !string.IsNullOrEmpty(r.RoomName))
            .GroupBy(r => r.RoomType)
            .ToDictionary(g => g.Key, g => g.Select(r => r.RoomName).ToList());
        roomTypePicker.ItemsSource = roomData.Keys.ToList();
    }

    private void OnRoomTypeSelected(object sender, EventArgs e)
    {
        if (roomTypePicker.SelectedItem is string selectedType && roomData.TryGetValue(selectedType, out var rooms))
        {
            roomPicker.ItemsSource = rooms;
            roomPicker.SelectedItem = null;
        }
    }

    private async void OnEditRoomPicked(object sender, EventArgs e)
    {
        var room = await DB.GetRoomsCollection().Find(r => r.RoomName == roomPicker.SelectedItem.ToString()).FirstOrDefaultAsync();
        await Navigation.PushAsync(new EditRoomDetails(room));
    }

}