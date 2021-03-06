﻿using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityCommon
{
    public class GDocToTextAssetConverter : IGoogleDriveConverter<TextAsset>
    {
        public RawDataRepresentation[] Representations { get { return new RawDataRepresentation[] {
            new RawDataRepresentation(null, "application/vnd.google-apps.document")
        }; } }

        public string ExportMimeType { get { return "text/plain"; } }

        public TextAsset Convert (byte[] obj) => new TextAsset(Encoding.UTF8.GetString(obj));

        public Task<TextAsset> ConvertAsync (byte[] obj) => Task.FromResult(new TextAsset(Encoding.UTF8.GetString(obj)));

        public object Convert (object obj) => Convert(obj as byte[]);

        public async Task<object> ConvertAsync (object obj) => await ConvertAsync(obj as byte[]);
    }
}
