using System;
using System.Collections.Generic;

namespace RemotableObjects
{
    public interface IObserver
    {
        //void Notify(string text);
        void ContentDrape(List<ContentDrapInput> _drapinput);
    }

    [Serializable]
    public class ContentDrapInput
    {
        public DrappedFabricFilter DrappedFabricFilter { get; set; }
        public byte[] DrapeImage { get; set; }
        public string ImageWritePath { get; set; }
        public bool IsCopmress { get; set; }
        public ImageSizeEnumDto ImageSizeEnum { get; set; }
        public EditableDatabaseDetail Databasedetails { get; set; }
        public string DrapeFileName { get; set; }
    }

    [Serializable]
    public class EditableDatabaseDetail
    {
        public string ClientName { get; set; }
        public string DataSourceName { get; set; }
        public string DriveLetter { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string WorkStationId { get; set; }
        public long CheckSum { get; set; }
        public List<string> IpAddresses { get; set; }
        public long SystemUserId { get; set; }
        public string UserName { get; set; }
        public string OrganizationId { get; set; }
    }

    /// <summary>The purpose of the <see cref="ImageSizeEnumDto"/> class is...</summary>  
    [Serializable]
    public enum ImageSizeEnumDto
    {
        /// <summary>
        /// Enum for HundredPercent
        /// </summary>
        _100 = 0,

        /// <summary>
        /// Enum for SeventyFivePercent
        /// </summary>
        _75 = 1,

        /// <summary>
        /// Enum for FiftyPercent
        /// </summary>
        _50 = 2,

        /// <summary>
        /// Enum for TwentyFivePercent
        /// </summary>
        _25 = 3
    }

    [Serializable]
    public class DrappedFabricFilter
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DrappedFabricFilter()
        {
            DrapeColor = "FFFFFF";
        }

        #endregion Constructor

        #region Properties

        /// <summary> ProductConfigurationId </summary>  
        public long ProductConfigurationId { get; set; }

        /// <summary> Gets or sets the link image product configuration id. </summary>
        /// <value> The link image product configuration id. </value>   
        public long? LinkImageProductConfigurationId { get; set; }

        /// <summary> Gets or sets the Main link image product configuration id. </summary>
        /// <value> The Main link image product configuration id. </value>   
        public long? MainLinkImageProductConfigurationId { get; set; }

        /// <summary> ProductAlignmentId </summary>        
        public long ProductAlignmentId { get; set; }

        /// <summary> FabricSwatchId </summary>    
        public long FabricSwatchId { get; set; }

        /// <summary> DrapeColor </summary>
        public string DrapeColor { get; set; }

        /// <summary> Image Enum. </summary>            [DataMember]
        public ImageEnumDto ImageType { get; set; }

        /// <summary> Gets or sets the three D groups. </summary>
        /// <value> The three D groups. </value>
        public List<ThreeDGroupDto> ThreeDGroups { get; set; }

        /// <summary> order </summary>
        public int orderno { get; set; }

        #endregion Properties
    }


    /// <summary> ThreeDGroupDto </summary>         
    [Serializable]
    public class ThreeDGroupDto
    {
        #region Properties

        /// <summary> Gets or sets the fabric swatch id. </summary>
        /// <value> The fabric swatch id. </value>
        public long FabricSwatchId { get; set; }

        /// <summary> Gets or sets the color of the drape. </summary>
        /// <value> The color of the drape. </value>
        public string DrapeColor { get; set; }

        /// <summary> Gets or sets the fabric image. </summary>
        /// <value> The fabric image. </value>
        public byte[] FabricImage { get; set; }

        public int GroupOrderNo { get; set; }

        #endregion Properties
    }


    /// <summary>  Enum For Image table. </summary>
    [Serializable]
    public enum ImageEnumDto
    {
        /// <summary>
        /// Enum for Thumb
        /// </summary>
        Thumb,

        /// <summary>
        /// Enum for Best Fit
        /// </summary>
        BestFit,

        /// <summary>
        /// Enum for Full
        /// </summary>
        Full,

        /// <summary>
        /// Enum for Specific
        /// </summary>
        Specific,

        /// <summary>
        /// Small
        /// </summary>
        Small,

        /// <summary>
        /// Large
        /// </summary>
        Large,

        /// <summary>
        /// None
        /// </summary>
        None
    }


}
