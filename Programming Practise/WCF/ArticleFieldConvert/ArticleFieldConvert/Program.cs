using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSConvertor;

namespace ArticleFieldConvert
{
    class Program
    {
        private enum DataBaseType { None = 0, Source = 1, Target = 2, Difference = 3 }

        static void Main(string[] args)
        {
            //#region Deleting Existing Data

            //DeleteExistingData("FieldMasters");
            //Console.WriteLine("Delete FieldMaster complete...");

            //DeleteExistingData("ProductTypes");
            //Console.WriteLine("Delete ProductTypes complete...");

            //DeleteExistingData("ProductGroups");
            //Console.WriteLine("Delete ProductGroups complete...");

            //DeleteExistingData("ProductFeatures");
            //Console.WriteLine("Delete ProductFeatures complete...");

            //DeleteExistingData("ProductFeatureTypes");
            //Console.WriteLine("Delete ProductFeatureTypes complete...");

            //DeleteExistingData("ArticleMaster");
            //Console.WriteLine("Delete ArticleMaster complete...");

            //DeleteExistingData("FolderMasters");
            //Console.WriteLine("Delete FolderMasters complete...");

            //DeleteExistingData("ThreeDCollections");
            //Console.WriteLine("Delete ThreeDCollections complete...");

            //DeleteExistingData("ThreeDSubjects");
            //Console.WriteLine("Delete ThreeDSubjects complete...");

            //DeleteExistingData("DraftMaster");
            //Console.WriteLine("Delete DraftMaster complete...");

            //DeleteExistingData("PegMaster");
            //Console.WriteLine("Delete PegMaster complete...");

            //DeleteExistingData("ArticleFieldMasters");
            //Console.WriteLine("Delete ArticleFieldMaster complete...");

            //DeleteExistingData("PatternMasters");
            //Console.WriteLine("Delete PatternMasters complete...");

            //DeleteExistingData("WeaveMasters");
            //Console.WriteLine("Delete WeaveMasters complete...");

            //DeleteExistingData("ColorLibraryMasters");
            //Console.WriteLine("Delete ColorLibraryMasters complete...");

            //DeleteExistingData("GrayYarnMasters");
            //Console.WriteLine("Delete GrayYarnMasters complete...");

            //DeleteExistingData("BarcodeTemplateSettings");
            //Console.WriteLine("Delete BarcodeTemplateSettings complete...");

            //DeleteExistingData("PaletteFiles");
            //Console.WriteLine("Delete PaletteFiles complete...");

            //DeleteExistingData("FabricMasters");
            //Console.WriteLine("Delete FabricMasters complete...");

            //DeleteExistingData("CustomerMasters");
            //Console.WriteLine("Delete CustomerMasters complete...");

            //DeleteExistingData("YarnCodeMasters");
            //Console.WriteLine("Delete YarnCodeMasters complete...");

            //DeleteExistingData("ConfigureFabricMasterFields");
            //Console.WriteLine("Delete ConfigureFabricMasterFields complete...");

            //DeleteExistingData("Currencies");
            //Console.WriteLine("Delete Currencies complete...");

            //DeleteExistingData("YarnMasters");
            //Console.WriteLine("Delete YarnMasters complete...");

            //DeleteExistingData("LinkYarnMasterForDesignDobbies");
            //Console.WriteLine("Delete LinkYarnMasterForDesignDobbies complete...");

            //DeleteExistingData("Subscriptions");
            //Console.WriteLine("Delete Subscriptions complete...");

            //DeleteExistingData("DesignMasters");
            //Console.WriteLine("Delete DesignMasters complete...");

            //DeleteExistingData("VariantMasters");
            //Console.WriteLine("Delete VariantMasters complete...");

            //DeleteExistingData("DesignMatchings");
            //Console.WriteLine("Delete DesignMatchings complete...");

            //DeleteExistingData("ProductConfigurations");
            //Console.WriteLine("Delete ProductConfigurations complete...");

            //DeleteExistingData("RoleProductConfigurations");
            //Console.WriteLine("Delete RoleProductConfigurations complete...");

            //DeleteExistingData("DesignMatchingSvs");
            //Console.WriteLine("Delete DesignMatchingSvs complete...");

            //DeleteExistingData("ConfigureSearchParameters");
            //Console.WriteLine("Delete ConfigureSearchParameters complete...");

            //DeleteExistingData("DesignDetails");
            //Console.WriteLine("Delete DesignDetails complete...");

            //DeleteExistingData("YarnColorMasters");
            //Console.WriteLine("Delete YarnColorMasters complete...");

            //DeleteExistingData("DesignDetailSvs");
            //Console.WriteLine("Delete DesignDetailSvs complete...");

            //DeleteExistingData("DesignGreyFinishDetails");
            //Console.WriteLine("Delete DesignGreyFinishDetails complete...");

            //DeleteExistingData("ThreeDConfigurations");
            //Console.WriteLine("Delete ThreeDConfigurations complete...");

            //DeleteExistingData("ThreeDImages");
            //Console.WriteLine("Delete ThreeDImages complete...");

            //DeleteExistingData("LinkProductDatas");
            //Console.WriteLine("Delete LinkProductDatas complete...");

            //DeleteExistingData("ConfigureTechnicalFields");
            //Console.WriteLine("Delete ConfigureTechnicalFields complete...");

            //DeleteExistingData("ColorMasters");
            //Console.WriteLine("Delete ColorMasters complete...");

            //DeleteExistingData("BarcodePreferences");
            //Console.WriteLine("Delete BarcodePreferences complete...");

            //DeleteExistingData("ConfigureFabricMasters");
            //Console.WriteLine("Delete ConfigureFabricMasters complete...");

            //DeleteExistingData("LinkCustomerDesignConfigurations");
            //Console.WriteLine("Delete LinkCustomerDesignConfigurations complete...");

            //DeleteExistingData("SapFiles");
            //Console.WriteLine("Delete SapFiles complete...");

            //DeleteExistingData("WeftVarients");
            //Console.WriteLine("Delete WeftVarients complete...");

            //DeleteExistingData("WarpVarients");
            //Console.WriteLine("Delete WarpVarients complete...");
            //#endregion


            #region Conversion

            //InsertData("FieldMasters");
            //Console.WriteLine("Insert FieldMaster complete...");

            //InsertData("ProductTypes");
            //Console.WriteLine("Insert ProductTypes complete...");

            //InsertData("ProductGroups");
            //Console.WriteLine("Insert ProductGroups complete...");

            //InsertData("ProductFeatures");
            //Console.WriteLine("Insert ProductFeatures complete...");

            InsertData("ProductFeatureTypes");
            Console.WriteLine("Insert ProductFeatureTypes complete...");

            InsertArticleMaster();
            Console.WriteLine("Insert ArticleMaster complete...");

            InsertData("FolderMasters");
            Console.WriteLine("Insert FolderMasters complete...");

            InsertData("ThreeDCollections");
            Console.WriteLine("Insert ThreeDCollections complete...");

            InsertData("ThreeDSubjects");
            Console.WriteLine("Insert ThreeDSubjects complete...");

            InsertDraftMaster();
            Console.WriteLine("Insert DraftMaster complete...");

            InsertPegMaster();
            Console.WriteLine("Insert PegMaster complete...");

            InsertData("ArticleFieldMasters");
            Console.WriteLine("Insert ArticleFieldMaster complete...");

            InsertPatternMasters();
            Console.WriteLine("Insert PatternMasters complete...");

            InsertWeaveMasters();
            Console.WriteLine("Insert WeaveMasters complete...");

            InsertColorLibraryMasters();
            Console.WriteLine("Insert ColorLibraryMasters complete...");

            InsertGrayYarnMasters();
            Console.WriteLine("Insert GrayYarnMasters complete...");

            InsertData("BarcodeTemplateSettings");
            Console.WriteLine("Insert BarcodeTemplateSettings complete...");

            InsertData("PaletteFiles");
            Console.WriteLine("Insert PaletteFiles complete...");

            InsertData("FabricMasters");
            Console.WriteLine("Insert FabricMasters complete...");

            InsertData("CustomerMasters");
            Console.WriteLine("Insert CustomerMasters complete...");

            InsertData("YarnCodeMasters");
            Console.WriteLine("Insert YarnCodeMasters complete...");

            InsertData("ConfigureFabricMasterFields");
            Console.WriteLine("Insert ConfigureFabricMasterFields complete...");

            InsertData("Currencies");
            Console.WriteLine("Insert Currencies complete...");

            InsertData("YarnMasters");
            Console.WriteLine("Insert YarnMasters complete...");

            InsertData("LinkYarnMasterForDesignDobbies");
            Console.WriteLine("Insert LinkYarnMasterForDesignDobbies complete...");

            InsertData("Subscriptions");
            Console.WriteLine("Insert Subscriptions complete...");

            InsertData("DesignMasters");
            Console.WriteLine("Insert DesignMasters complete...");

            InsertVariantMasters();
            Console.WriteLine("Insert VariantMasters complete...");

            InsertData("DesignMatchings");
            Console.WriteLine("Insert DesignMatchings complete...");

            InsertData("ProductConfigurations");
            Console.WriteLine("Insert ProductConfigurations complete...");

            InsertData("RoleProductConfigurations");
            Console.WriteLine("Insert RoleProductConfigurations complete...");

            InsertData("DesignMatchingSvs");
            Console.WriteLine("Insert DesignMatchingSvs complete...");

            InsertData("ConfigureSearchParameters");
            Console.WriteLine("Insert ConfigureSearchParameters complete...");

            InsertDesignDetails();
            Console.WriteLine("Insert DesignDetails complete...");

            InsertYarnColorMasters();
            Console.WriteLine("Insert YarnColorMasters complete...");

            InsertData("DesignDetailSvs");
            Console.WriteLine("Insert DesignDetailSvs complete...");

            InsertData("DesignGreyFinishDetails");
            Console.WriteLine("Insert DesignGreyFinishDetails complete...");

            InsertData("ThreeDConfigurations");
            Console.WriteLine("Insert ThreeDConfigurations complete...");

            InsertData("ThreeDImages");
            Console.WriteLine("Insert ThreeDImages complete...");

            InsertData("LinkProductDatas");
            Console.WriteLine("Insert LinkProductDatas complete...");

            InsertData("ConfigureTechnicalFields");
            Console.WriteLine("Insert ConfigureTechnicalFields complete...");

            InsertColorMasters();
            Console.WriteLine("Insert ColorMasters complete...");

            ////////////InsertData("ColorMasters");
            ////////////Console.WriteLine("Insert ColorMasters complete...");

            InsertData("BarcodePreferences");
            Console.WriteLine("Insert BarcodePreferences complete...");

            InsertData("ConfigureFabricMasters");
            Console.WriteLine("Insert ConfigureFabricMasters complete...");

            InsertData("LinkCustomerDesignConfigurations");
            Console.WriteLine("Insert LinkCustomerDesignConfigurations complete...");

            InsertData("SapFiles");
            Console.WriteLine("Insert SapFiles complete...");

            InsertWeftVarients();
            Console.WriteLine("Insert WeftVarients complete...");

            InsertWarpVarients();
            Console.WriteLine("Insert WarpVarients complete...");



            InsertData("ProjectMasters");
            Console.WriteLine("Insert ProjectMasters complete...");

            InsertData("ShowRoomMyCarts");
            Console.WriteLine("Insert ShowRoomMyCarts complete...");

            InsertData("MyCarts");
            Console.WriteLine("Insert MyCarts complete...");

            InsertData("Countries");
            Console.WriteLine("Insert Countries complete...");

            InsertData("MyUsers");
            Console.WriteLine("Insert MyUsers complete...");

            ////InsertData("DateTimeUnits");
            ////Console.WriteLine("Insert DateTimeUnits complete...");

            InsertData("CollectionConfigurations");
            Console.WriteLine("Insert CollectionConfigurations complete...");

            InsertData("CollectionMasters");
            Console.WriteLine("Insert CollectionMasters complete...");

            InsertData("SeasonalCollectionConfigurations");
            Console.WriteLine("Insert SeasonalCollectionConfigurations complete...");

            InsertData("SeasonalCollections");
            Console.WriteLine("Insert SeasonalCollections complete...");

            InsertData("SeasonalCollectionFeaturesTypes");
            Console.WriteLine("Insert SeasonalCollectionFeaturesTypes complete...");

            InsertData("SeasonalCollectionColors");
            Console.WriteLine("Insert SeasonalCollectionColors complete...");

            InsertData("DesignCollections");
            Console.WriteLine("Insert DesignCollections complete...");

            InsertData("ThreeDImageXmlConfigurations");
            Console.WriteLine("Insert ThreeDImageXmlConfigurations complete...");

            InsertData("ConfigureDesignFeatureTypes");
            Console.WriteLine("Insert ConfigureDesignFeatureTypes complete...");

            InsertData("DesignLibraryConfigurations");
            Console.WriteLine("Insert DesignLibraryConfigurations complete...");



            InsertData("StyleMeImages");
            Console.WriteLine("Insert StyleMeImages complete...");

            InsertData("ProductPointDefinations");
            Console.WriteLine("Insert ProductPointDefinations complete...");

            InsertData("BlockedProductConfigurations");
            Console.WriteLine("Insert BlockedProductConfigurations complete...");


            InsertData("AdminInfoes");
            Console.WriteLine("Insert AdminInfoes complete...");


            InsertData("DressingRoomImages");
            Console.WriteLine("Insert DressingRoomImages complete...");

            InsertData("PopularLooks");
            Console.WriteLine("Insert PopularLooks complete...");


            InsertData("ConfigurePopularLooks");
            Console.WriteLine("Insert ConfigurePopularLooks complete...");


            InsertData("TryOnMappedImages");
            Console.WriteLine("Insert TryOnMappedImages complete...");

            InsertData("ProductGroupCombinations");
            Console.WriteLine("Insert ProductGroupCombinations complete...");

            countdifferencs();
            Console.WriteLine("Count Differencs Finished");

            Console.WriteLine(" Finished...");
            Console.ReadKey();

            #endregion
        }




        //private static void DeleteExistingData(string TableName)
        //{
        //    try
        //    {
        //        string query = string.Format("DELETE FROM [{0}].[dbo].[{1}]", GetDatabaseName(DataBaseType.Target), TableName);
        //        ExecuteNonQuery(query, DataBaseType.Target);
        //    }
        //    catch (Exception e)
        //    {
        //        CLog.LogMessage(e.ToString());
        //    }
        //}

        private static void InsertData(string TableName)
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("INSERT INTO [{0}].[dbo].[" + TableName + "]", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select * from  [{0}].[dbo].[" + TableName + "]", GetDatabaseName(DataBaseType.Source));
                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {

                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertGrayYarnMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("INSERT INTO [{0}].[dbo].[GrayYarnMasters](GrayYarnMasterId,GrayYarnName,GrayYarnType,GrayYarnData,Blend,Twist,[Type],[Version],IsLatest,CreatedBy,CreatedOn,IsDeleted,DeletedBy,[CheckSum])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select GrayYarnMasterId,GrayYarnName,GrayYarnType,GrayYarnData,Blend,Twist,[Type],[Version],IsLatest,CreatedBy,CreatedOn,IsDeleted,DeletedBy,[CheckSum] from [{0}].[dbo].[GrayYarnMasters]", GetDatabaseName(DataBaseType.Source));
                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertYarnColorMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("INSERT INTO [{0}].[dbo].[YarnColorMasters](YarnColorMasterId,LibraryMasterId,Yarn_Name,Yarn_Code,Yarn_Description,[Version],Yarn_PosX," +
                    "Yarn_PosY,Yarn_Data,Yarn_Blend,Yarn_Twist,Yarn_Type,Yarn_Composition,Yarn_Cost,Yarn_Season,Yarn_Season1,Yarn_Season2,Yarn_GrayYarnMasterId,Yarn_Count," +
                    "Yarn_Ply,Yarn_CountType,Yarn_Category,Yarn_Mixing,Yarn_ResultCount,Yarn_MixingCode,Yarn_IsUse,Yarn_CreatedBy,Yarn_CreatedOn,Yarn_IsDeleted,Yarn_DeletedBy," +
                    "Yarn_DeletedOn,Yarn_Checksum,Yarn_IsLatest,Yarn_ChecksumOfName,Yarn_IsFcyColType)", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select [YarnColorMasterId],[LibraryMasterId],[YarnName],[YarnCode],[Version],[PosX],[PosY],[YarnData],[YarnType],[Blend],[Twist],[Type]," +
                                        "[Composition],[YarnCost],[Season],[Season1],[Season2],[CreatedBy],[CreatedOn],[DeletedBy],[DeletedOn],[Description],[Checksum]," +
                                        "[IsLatest],[IsDeleted],[YarnCount],[YarnPly],[YarnCountType],[YarnCategory],[YarnMixing],[YarnResultCount],[YarnMixingCode]," +
                                        "[IsUse],[ChecksumOfName],[IsFcyColType] from [{0}].[dbo].[YarnColorMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertPatternMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("INSERT INTO [{0}].[dbo].[PatternMasters](PatternMasterId,PatternName,[Version],IsLatest,Pattern,PatternCount,ColorCount,CreatedBy," +
                    "CreatedOn,DeletedBy,DeletedOn,IsDeleted,[Description],[CheckSum])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select PatternMasterId,PatternMasterName,[Version],IsLatest,PatternMasterPattern,PatternSize,ColorCount,CreatedBy,CreatedOn," +
                    "DeletedBy,DeletedOn,IsDeleted,[Description],[CheckSum] from [{0}].[dbo].[PatternMasters]", GetDatabaseName(DataBaseType.Source));
                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertWeaveMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("INSERT INTO [{0}].[dbo].[WeaveMasters]([WeaveMasterId],[WeaveName],[Version],[IsLatest],[WeaveData],[Ends]," +
                                             "[Picks],[CreatedBy],[CreatedOn],[IsDeleted],[DeletedBy],[DeletedOn],[Description],[CheckSum])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select WeaveMasterId,WeaveMasterName,[Version],IsLatest,WeaveMasterData,Width,Height,CreatedBy,CreatedOn," +
                                       "IsDeleted,DeletedBy,DeletedOn,[Description],[CheckSum] from [{0}].[dbo].[WeaveMasters]", GetDatabaseName(DataBaseType.Source));
                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertWarpVarients()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[WarpVarients] ([WarpVariantID],[DesignID],[Var_WarpIndex],[Var_WarpYarnId],[Var_WarpComposition],[Var_WarpData]," +
                                             "[Var_WarpColorways],[Version],[IsLatest],[IsDeleted])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select WarpVariantID,DesignID,WarpIndex,WarpId,Composition,Warp,WarpColorWay,[Version],IsLatest,IsDeleted from [{0}].[dbo].[WarpVarients]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertColorMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[ColorMasters] ([ColorMasterId],[LibraryMasterId],[Checksum],[Clr_ColorCode],[Clr_ColorName]," +
                                             "[Clr_Description],[Clr_PosX],[Clr_PosY],[Clr_ScreenRed],[Clr_ScreenGreen],[Clr_ScreenBlue],[Clr_ScreenHue],[Clr_ScreenSat]," +
                                             "[Clr_ScreenVal],[Clr_PrinterRed],[Clr_PrinterGreen],[Clr_PrinterBlue],[Clr_PrinterHue],[Clr_PrinterSat],[Clr_PrinterVal]," +
                                             "[Clr_Season],[Clr_Season1],[Clr_Season2],[Clr_IsUse],[Clr_ChecksumOfName],[Clr_Version],[Clr_IsLatest],[Clr_IsView]," +
                                             "[Clr_CreatedBy],[Clr_CreatedOn],[Clr_IsDeleted],[Clr_DeletedBy],[Clr_DeletedOn])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select [ColorMasterId],[LibraryMasterId],[Checksum],[ColorCode],[ColorName],[Description],[PosX],[PosY],[ScreenRed],[ScreenGreen]," +
                                       "[ScreenBlue],[ScreenHue],[ScreenSat],[ScreenVal],[PrinterRed],[PrinterGreen],[PrinterBlue],[PrinterHue],[PrinterSat],[PrinterVal]," +
                                       "[Season],[Season1],[Season2],[IsUse],[ChecksumOfName],[Version],[IsLatest],[IsView],[CreatedBy],[CreatedOn],[IsDeleted],[DeletedBy]," +
                                        "[DeletedOn] from [{0}].[dbo].[ColorMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertArticleMaster()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[ArticleMasters] ([Art_ArticleId],[Art_CreatedBy],[Art_CreatedOn],[Art_ArticleName],[Art_Description],[Art_Type]," +
                                             "Art_Unit,[Art_ReedCount],[Art_AvgDent],[Art_WarpDensity],[Art_WeftDensity],[Art_FinishWarpDensity],[Art_FinishWeftDensity]," +
                                             "[Art_ReedSpace],[Art_GreyWidth],[Art_FinishWidth],[Art_SelvDent],[Art_SelvEnd],[Art_TotalSelvEnd],[Art_MonoDent]," +
                                             "[Art_MonoEnds],[Art_TotalDents],[Art_TotalEnds],[Art_WarpCount],[Art_WarpPly],[Art_WarpCountType],[Art_WeftCount],[Art_WeftPly]," +
                                             "[Art_WeftCountType],[Art_Glm],[Art_Gsm],[Art_DraftMasterId],[Art_PegMasterId],[Art_WarpMasterId],[Art_WeftMasterId]," +
                                             "[Art_NoOfShaft])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select ArticleId,ArticleCreatedBy,ArticleCreatedOn,ArticleName,ArticleDescription,ArticleType,ArticleUnit,ArticleReedCount,ArticleAvgDent," +
                                       "ArticleGreyEpi,ArticleGreyPpi,ArticleFinishEpi,ArticleFinishPpi,ArticleReedSpace,ArticleGreyWidth,ArticleFinishWidth,ArticleSelvDent," +
                                       "ArticleSelvEnd,ArticleTotalSelvEnd,ArticleMonoDent,ArticleMonoEnds,ArticleTotalDents,ArticleTotalEnds,ArticleWarpCount,ArticleWarpPly," +
                                       "ArticleWarpCountType,ArticleWeftCount,ArticleWeftPly,ArticleWeftCountType,ArticleGlm,[ArticleGsm],ArticleDraftMasterId,ArticlePegMasterId," +
                                       "ArticleWarpMasterId,ArticleWeftMasterId,ArticleNoOfShaft from [{0}].[dbo].[ArticleMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }

        private static void InsertDraftMaster()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[DraftMasters](DraftMasterId,DraftCode,DraftShafts,DraftEnds,DraftPattern,DentPattern,DentsVariation," +
       "[CheckSum],[Description],CreatedBy,CreatedOn,[Version],IsLatest,IsDeleted,DeletedBy,DeletedOn)", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select [DraftMasterId],[DraftMasterName],[Height],[Width],[DraftMasterPattern],[DentPattern],[Dents],[CheckSum]," +
                "[Description],[CreatedBy],[CreatedOn],[Version],[IsLatest],[IsDeleted],[DeletedBy],[DeletedOn] from [{0}].[dbo].[DraftMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }

        }

        private static void InsertPegMaster()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[PegMasters] (PegMasterId,PegCode,PegShafts,PegPicks,PegPattern,KOrd,KTar," +
       "KMed,[Description],CreatedBy,CreatedOn,[CheckSum],[Version],IsLatest,IsDeleted,DeletedBy,DeletedOn)", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select PegMasterId,PegMasterName,[Width],[Height],PegMasterPattern,KOrd,KTar,KMed," +
       "[Description],[CreatedBy],[CreatedOn],[CheckSum],[Version],[IsLatest],[IsDeleted],[DeletedBy],[DeletedOn] from [{0}].[dbo].[PegMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }

        private static void InsertColorLibraryMasters()
        {
            try
            {

                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[ColorLibraryMasters]([LibraryMasterId],[LibraryName],[LibraryType],[Description],[OldLibraryName]," +
                                            "[NoOfColumns],[NoOfRows],[CreatedBy],[CreatedOn],[Version],[IsLatest],[IsDeleted],[DeletedBy],[DeletedOn])", GetDatabaseName(DataBaseType.Target));

                query += string.Format("  select LibraryMasterId,LibraryMasterName,LibraryType,[Description],ColorOldName,NoOfColumns,NoOfRows,CreatedBy,CreatedOn," +
                                        "[Version],IsLatest,IsDeleted,DeletedBy,DeletedOn from [{0}].[dbo].[ColorLibraryMasters]", GetDatabaseName(DataBaseType.Source));

                //string query = string.Format("insert into [{0}].[dbo].[ColorLibraryMasters]( [LibraryMasterId],[LibraryType],[Description],[NoOfColumns],[NoOfRows],"+
                //                             "[CreatedBy],[CreatedOn],[Version],[IsLatest],[IsDeleted],[DeletedBy],[DeletedOn],[LibraryMasterName],[ColorOldName])", GetDatabaseName(DataBaseType.Target));

                //query += string.Format("  select  [LibraryMasterId],[LibraryType],[Description],[NoOfColumns],[NoOfRows],[CreatedBy],[CreatedOn],[Version],"+
                //                       "[IsLatest],[IsDeleted],[DeletedBy],[DeletedOn],[LibraryMasterName],[ColorOldName] from [{0}].[dbo].[ColorLibraryMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);

            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }


        //private static void InsertColorMasters()
        //{
        //    try
        //    {

        //        string constring = GetConnectionString(DataBaseType.Target);
        //        SqlConnection _Connectionstring = new SqlConnection(constring);
        //        if (_Connectionstring.State == ConnectionState.Closed)
        //            _Connectionstring.Open();
        //        string query = string.Format("insert into [{0}].[dbo].[ColorMasters]([ColorMasterId],[LibraryMasterId],[Clr_ColorCode],[Clr_Description],[Clr_PosX]," +
        //  "[Clr_PosY],[Clr_ScreenRed],[Clr_ScreenGreen],[Clr_ScreenBlue],[Clr_ScreenHue],[Clr_ScreenSat],[Clr_ScreenVal],[Clr_PrinterRed],[Clr_PrinterGreen]," +
        //  "[Clr_PrinterBlue],[Clr_PrinterHue],[Clr_PrinterSat],[Clr_PrinterVal],[Checksum] ,[Clr_Season],[Clr_Season1],[Clr_Season2]," +
        //  "[Clr_IsUse] ,[Clr_ChecksumOfName],[Clr_Version],[Clr_IsLatest],[Clr_IsView],[Clr_CreatedBy],[Clr_CreatedOn],[Clr_IsDeleted]," +
        //  "[Clr_DeletedBy],[Clr_DeletedOn])", GetDatabaseName(DataBaseType.Target));

        //        query += string.Format(" select ColorMasterId,LibraryMasterId,ColorCode,[Description],PosX,PosY,ScreenRed,ScreenGreen,ScreenBlue,ScreenHue,ScreenSat," +
        //        "ScreenVal,PrinterRed,PrinterGreen,PrinterBlue,PrinterHue,PrinterSat,PrinterVal,[Checksum],Season,Season1,Season2,IsUse,ChecksumOfName,[Version],IsLatest," +
        //        "IsView,CreatedBy,CreatedOn,IsDeleted,DeletedBy,DeletedOn from [{0}].[dbo].[ColorMasters]", GetDatabaseName(DataBaseType.Source));

        //        ExecuteNonQuery(query, DataBaseType.Target);

        //    }
        //    catch (Exception e)
        //    {
        //        CLog.LogMessage(e.ToString());
        //    }
        //}

        private static void InsertVariantMasters()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[VariantMasters]( [VariantMasterId],[DesignId],[Var_Season],[Var_MainSeason],[Var_BlkSeason],[Var_BlkName]," +
                                             "[Var_BlkWarpNo],[Var_BlkWeftNo],[Var_Composition] ,[Var_WeftDensity],[Var_Description1],[Var_Description2],[Var_Description3],[Var_VariantNote]," +
                                             "[Var_FinishingCode])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select VariantMasterId,DesignId,Season,MainSeason,BlanketSeason,BlanketName,CrossNoofwarps,CrossNoofWefts,Composition,WeftDensity,Notes2,Notes3," +
                    "Notes4,NotesColor,FinishedCode from [{0}].[dbo].[VariantMasters]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }

        private static void InsertWeftVarients()
        {
            try
            {
                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[WeftVarients]( [WeftVariantId],[DesignId],[Var_WeftIndex],[Var_WeftYarnId],[Var_WeftComposition],[Var_WeftData]," +
                "[Var_WeftColorWay],[Version],[IsLatest],[IsDeleted])", GetDatabaseName(DataBaseType.Target));

                query += string.Format("  select WeftVariantId,DesignId,WeftIndex,WeftId,Composition,Weft,WeftColorWay,[Version],IsLatest,IsDeleted from [{0}].[dbo].[WeftVarients]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }


        private static void InsertDesignDetails()
        {
            try
            {

                string constring = GetConnectionString(DataBaseType.Target);
                SqlConnection _Connectionstring = new SqlConnection(constring);
                if (_Connectionstring.State == ConnectionState.Closed)
                    _Connectionstring.Open();
                string query = string.Format("insert into [{0}].[dbo].[DesignDetails]([DesignDetailId],[DesignId],[ProductTypeId],[ProductGroupId],[Des_Type],[Des_Unit],[Des_ReedCount]," +
                "[Des_AvgDent],[Des_WarpDensity],[Des_WeftDensity],[Des_FinishWarpDensity],[Des_FinishWeftDensity],[Des_ReedSpace],[Des_GreyWidth],[Des_FinishWidth],[Des_SelvDent],[Des_SelvEnd]," +
                "[Des_TotalSelvEnd],[Des_MonoDent],[Des_MonoEnds],[Des_TotalDents],[Des_TotalEnds],[Des_WarpCount],[Des_WarpPly],[Des_WarpCountType],[Des_WeftCount],[Des_WeftPly],[Des_WeftCountType]," +
                "[Des_Glm],[Des_Gsm],[Des_DraftMasterId],[Des_PegMasterId],[Des_WarpMasterId],[Des_WeftMasterId],[Des_NoOfShaft],[Des_DesignerName],[Des_WarpSize],[Des_WeftSize],[Des_TotalWarpYarns]," +
                "[Des_TotalWeftYarns],[Des_DraftPattern],[Des_DraftShaft],[Des_DraftEnds],[Des_PegPattern],[Des_PegShaft],[Des_PegPicks],[Des_WarpPattern],[Des_WarpPatternCount],[Des_WeftPattern]," +
                "[Des_WeftPatternCount],[Des_SelvDraftMasterId],[Des_SelvPegMasterId],[Des_SelvWarpMasterId],[Des_SelvDraftPattern],[Des_SelvDraftShaft],[Des_SelvDraftEnds],[Des_SelvPegPattern]," +
                "[Des_SelvPegShaft],[Des_SelvPegPicks],[Des_SelvWarpPattern],[Des_SelvWarpCount],[Des_SelvWarpColor],[Des_MonoWarpMasterId],[Des_MonoWarpPattern],[Des_MonoWarpCount],[Des_MonoWarpColor]," +
                "[Des_ExtraWarp],[Des_ExtraWarpCount],[Des_ExtraWeft],[Des_ExtraWeftCount],[Des_TopBeamWarp],[Des_TopBeamWarpCount])", GetDatabaseName(DataBaseType.Target));

                query += string.Format(" select DesignDetailId,DesignId,ProductTypeId,ProductGroupId,DesignType,DesignUnit,DesignReedCount,DesignAvgDent,DesignGreyEpi,DesignGreyPpi,DesignFinishEpi," +
                "DesignFinishPpi,DesignReedSpace,DesignGreyWidth,DesignFinishWidth,DesignSelvDent,DesignSelvEnd,DesignTotalSelvEnd,DesignMonoDent,DesignMonoEnds,DesignTotalDents,DesignTotalEnds," +
                "DesignWarpCount,DesignWarpPly,DesignWarpCountType,DesignWeftCount,DesignWeftPly,DesignWeftCountType,DesignGlm,DesignGsm,DesignDraftMasterId,DesignPegMasterId,DesignWarpMasterId," +
                "DesignWeftMasterId,DesignNoOfShaft,DesignerName,DesignSizeWarp,DesignSizeWeft,NumberOfColorWarp,NumberOfColorWeft,DraftPattern,DraftShaft,DraftEnds,PegPattern," +
                "PegShaft,PegPicks,WarpPattern,WarpCount,WeftPattern,WeftCount,SelvedgeDraftMasterId,SelvedgePegMasterId,SelvedgeWarpMasterId,SelvedgeDraftPattern,SelvedgeDraftShaft," +
                "SelvedgeDraftEnds,SelvedgePegPattern,SelvedgePegShaft,SelvedgePegPicks,SelvedgeWarpPattern,SelvedgeWarpCount,SelvedgeWarpsColor,MonoWarpMasterId,MonoWarpPattern,MonoWarpCount," +
                "MonoWarpsColor,ExtraWarp,ExtraWarpCount,ExtraWeft,ExtraWeftCount,TopBeamWarp,TopBeamWarpCount from [{0}].[dbo].[DesignDetails]", GetDatabaseName(DataBaseType.Source));

                ExecuteNonQuery(query, DataBaseType.Target);
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());
            }
        }

        private static DataSet GetDataSet(string strQuery, string strTableName, DataBaseType dbType)
        {
            //WriteData(strQuery);
            var data = new SqlData(GetConnectionString(dbType));
            var ds = new DataSet();
            try
            {
                data.Command.CommandType = CommandType.Text;
                data.Command.CommandTimeout = 6000;
                data.Command.CommandText = strQuery;
                data.Fill(ref ds, strTableName);
                return ds;
            }
            catch (Exception e) { CLog.LogMessage(e.ToString()); }
            finally { CloseConnection(ref data); }
            return null;
        }

        private static string GetConnectionString(DataBaseType dbType)
        {
            switch (dbType)
            {
                case DataBaseType.Source:
                    return ConfigurationManager.ConnectionStrings["SourceDbConnection"].ConnectionString;
                case DataBaseType.Target:
                    return ConfigurationManager.ConnectionStrings["TargetDbConnection"].ConnectionString;
                case DataBaseType.Difference:
                    return ConfigurationManager.ConnectionStrings["SourceDb_difference"].ConnectionString;
                default:
                    return ConfigurationManager.ConnectionStrings["SourceDbConnection"].ConnectionString;
            }
        }

        public static bool IsDataSetExist(ref DataSet ds)
        {
            return (null != ds && null != ds.Tables && ds.Tables.Count > 0 && null != ds.Tables[0].Rows);
        }

        private static DataSet ExecuteNonQuery(string strQuery, DataBaseType dbType)
        {
            //WriteData(strQuery);
            var data = new SqlData(GetConnectionString(dbType));
            try
            {
                data.OpenConnection();
                data.Command.CommandType = CommandType.Text;
                data.Command.CommandTimeout = 6000;
                data.Command.CommandText = strQuery;
                data.Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //var query = strQuery.Split(']').Take(4).Skip(0).ToList();
                //string tablename = query[2].Replace(".[", "").ToString();
                //string str = e.ToString();
                //if (!str.Contains("Violation of PRIMARY KEY constraint 'PK_" + tablename + "'. Cannot insert duplicate key in object 'dbo." + tablename + "'. The duplicate key value is"))

                CLog.LogMessage(strQuery);
                CLog.LogMessage(e.ToString());
            }
            finally { CloseConnection(ref data); }
            return null;
        }

        private static string GetCheckSum(string str)
        {
            try
            {
                if (str == "")
                    return "0";
                if (str == "00000000-0000-0000-0000-000000000000")
                    return "0";

                byte[] buffer = new Guid(str).ToByteArray();
                long res = BitConverter.ToInt64(buffer, 0);
                string str1 = res.ToString();
                string newchecksum = str1.Substring(str1.Length - Math.Min(14, str1.Length));
                return newchecksum;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool checkidexitornot(string tablename, string Columnname, string Columnid, SqlConnection _Connectionstring)
        {
            try
            {
                //string connectionString = GetConnectionString(DataBaseType.Target);
                //SqlConnection _Connectionstring = new SqlConnection(connectionString);
                //if (_Connectionstring.State == ConnectionState.Closed)
                //    _Connectionstring.Open();

                var quer = "Select * from " + tablename + " Where " + Columnname + " = '" + Columnid + "' ";
                using (SqlCommand sqlCmd = new SqlCommand(quer, _Connectionstring))
                {
                    object resultObj = sqlCmd.ExecuteScalar();
                    if (resultObj != null)
                    {
                        //_Connectionstring.Close();
                        return true;
                    }
                    else
                    {
                        // _Connectionstring.Close();
                        return false;
                    }
                }
                //_Connectionstring.Close();
                return false;
            }
            catch (Exception e) { return false; }
        }

        private static string GetDatabaseName(DataBaseType dbType)
        {
            switch (dbType)
            {
                case DataBaseType.Source:
                    return new System.Data.SqlClient.SqlConnectionStringBuilder(GetConnectionString(DataBaseType.Source)).InitialCatalog;
                case DataBaseType.Target:
                    return new System.Data.SqlClient.SqlConnectionStringBuilder(GetConnectionString(DataBaseType.Target)).InitialCatalog;
                default:
                    return new System.Data.SqlClient.SqlConnectionStringBuilder(GetConnectionString(DataBaseType.Source)).InitialCatalog;
            }
        }

        private static long GetCheckSum_long(string str)
        {
            try
            {
                if (str == "")
                    return 0;
                if (str == "00000000-0000-0000-0000-000000000000")
                    return 0;

                byte[] buffer = new Guid(str).ToByteArray();
                long res = BitConverter.ToInt64(buffer, 0);
                string str1 = res.ToString();
                string newchecksum = str1.Substring(str1.Length - Math.Min(14, str1.Length));
                return Convert.ToInt64(newchecksum);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private static void CloseConnection(ref SqlData data)
        {
            data.Command.Dispose();
            data.CloseConnection();
        }

        public static object IfDBNull(ref DataRow row, string strColName, object oDefaultValue)
        {
            return IIfNull(row, strColName, oDefaultValue);
        }

        public static object IIfNull(DataRow row, string strColName, object oDefaultValue)
        {
            if (row != null)
            {
                return row.IsNull(strColName) ? oDefaultValue : row[strColName];
            }
            return null;
        }

        public static void countdifferencs()
        {
            try
            {
                int i = 0;
                //label2.Text = "count differencs....";
                //Application.DoEvents();
                //progressBar1.Minimum = 0;

                string driveletter = ConfigurationManager.AppSettings["driveletter"].ToString();
                string sourcedbconnection = Convert.ToString(ConfigurationManager.ConnectionStrings["SourceDbConnection"]);
                List<String> tableNames = new List<string>();
                tableNames = Tableorder.FindPrimaryandForeginKeyinTable(sourcedbconnection);
                //progressBar1.Maximum = tableNames.Count();

                string targetdbconnection = Convert.ToString(ConfigurationManager.ConnectionStrings["TargetDbConnection"]);
                SqlConnectionStringBuilder TargetDbConnection = new SqlConnectionStringBuilder();
                TargetDbConnection.ConnectionString = targetdbconnection;
                string targetDirectoryname = TargetDbConnection.InitialCatalog;

                if (!Directory.Exists(driveletter + ":\\" + targetDirectoryname))
                    Directory.CreateDirectory(driveletter + ":\\" + targetDirectoryname);
                string strExcelFileName = driveletter + ":\\" + targetDirectoryname + "\\CountDifferencs.xls";
                if (File.Exists(strExcelFileName))
                    File.Delete(strExcelFileName);
                IWorkbook workBook = null;
                workBook = new HSSFWorkbook();
                ISheet sheet = workBook.CreateSheet("CountDifferencs");

                var row = sheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("Table Name");
                row.CreateCell(1).SetCellValue("Guid Count");
                row.CreateCell(2).SetCellValue("Long Count");
                row.CreateCell(3).SetCellValue("Total differencs");

                var rowCount = 1;
                var newRow = sheet.CreateRow(rowCount);

                foreach (var tableName in tableNames)
                {
                    //progressBar1.Value = i;
                    string strquery = "Select Count(*) as counts From " + tableName;
                    var aresult = GetDataSet(strquery, tableName, DataBaseType.Source); // GetDataSet(strquery, tableName, sourcedbconnection);
                    var bresult = GetDataSet(strquery, tableName, DataBaseType.Target); //GetDataSet(strquery, tableName, targetdbconnection);

                    long acount = 0; long bcount = 0; long diff;
                    if (aresult != null)
                        foreach (DataRow rows in aresult.Tables[0].Rows)
                            acount = rows["counts"] == DBNull.Value ? 0 : Convert.ToInt64(rows["counts"].ToString());

                    if (bresult != null)
                        foreach (DataRow row1 in bresult.Tables[0].Rows)
                            bcount = row1["counts"] == DBNull.Value ? 0 : Convert.ToInt64(row1["counts"].ToString());
                    diff = acount - bcount;
                    rowCount++;
                    var newRow1 = sheet.CreateRow(rowCount);
                    newRow1.CreateCell(0).SetCellValue(tableName);
                    newRow1.CreateCell(1).SetCellValue(acount);
                    newRow1.CreateCell(2).SetCellValue(bcount);
                    newRow1.CreateCell(3).SetCellValue(diff);


                    i++;
                }

                FileStream sw = File.Create(strExcelFileName);
                workBook.Write(sw);
                sw.Close();
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

    }
}
