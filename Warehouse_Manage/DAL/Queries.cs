using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Manage.DAL
{


    public class MedNames
    {

        public double MedID { get; set; }
        public string MedName { get; set; }

    }

    class Queries
    {

        private List<MedNames> medNames;


        public List<MedNames> MedNames 
        { 
            get
            {
                medNames = new List<MedNames>();

                medNames.Add(new DAL.MedNames { MedID = 101.001, MedName = "Acidex A 02" });
                medNames.Add(new DAL.MedNames { MedID = 101.002, MedName = "OVEN 9 K 20 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.004, MedName = "TRT 1000DOZ 500ML-HIPRA" });
                medNames.Add(new DAL.MedNames { MedID = 101.005, MedName = "ACEDIX FG 120 10 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.006, MedName = "ACIDEX FG 80" });
                medNames.Add(new DAL.MedNames { MedID = 101.008, MedName = "ACIDEX-D20" });
                medNames.Add(new DAL.MedNames { MedID = 101.010, MedName = "Acidex-food B23-25" });
                medNames.Add(new DAL.MedNames { MedID = 101.017, MedName = "agristeryl 5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.0193, MedName = "فونيك مركز 4 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.020, MedName = "Altramen1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.023, MedName = "AMOXAL PLUS200" });
                medNames.Add(new DAL.MedNames { MedID = 101.034, MedName = "anticox 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.036, MedName = "AROMAVED100ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.037, MedName = "ascazin100gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.040, MedName = "aviflor 1lavico" });
                medNames.Add(new DAL.MedNames { MedID = 101.042, MedName = "avitaeen 1kg avico" });
                medNames.Add(new DAL.MedNames { MedID = 101.043, MedName = "avitryl-1l avico" });
                medNames.Add(new DAL.MedNames { MedID = 101.044, MedName = "avixavet1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.045, MedName = "avixin pluse1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.046, MedName = "b.k.m. 1kg avico" });
                medNames.Add(new DAL.MedNames { MedID = 101.057, MedName = "CALFAST 1 Ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.059, MedName = "CCOXIDIA SHERING1000DOS" });
                medNames.Add(new DAL.MedNames { MedID = 101.061, MedName = "c-enrox 10%`l" });
                medNames.Add(new DAL.MedNames { MedID = 101.062, MedName = "CEPHALEXINE500 AVICO" });
                medNames.Add(new DAL.MedNames { MedID = 101.063, MedName = "CERCUAL PLUS 1 Ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.063, MedName = "CEVAQ ND 5000DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.066, MedName = "CEVA ND-IB 5000DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.068, MedName = "CEVAMUNE" });
                medNames.Add(new DAL.MedNames { MedID = 101.071, MedName = "CIPROTIL" });
                medNames.Add(new DAL.MedNames { MedID = 101.072, MedName = "CLON-N79 1000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.076, MedName = "COLIPRIM-1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.077, MedName = "colistin 4800 wsp 1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.0772, MedName = "Aifcid 250g" });
                medNames.Add(new DAL.MedNames { MedID = 101.086, MedName = "DICLAVED2.5" });
                medNames.Add(new DAL.MedNames { MedID = 101.087, MedName = "DILENT FOR VACCIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.088, MedName = "DIURIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.090, MedName = "DOXAL-AD3E1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.092, MedName = "DOXCYFORT-500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.093, MedName = "DOXY CYCLINE 50% WSP" });
                medNames.Add(new DAL.MedNames { MedID = 101.097, MedName = "doxystin aveco 500gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.098, MedName = "DUSTRIN 5%" });
                medNames.Add(new DAL.MedNames { MedID = 101.1000, MedName = "NOROMECTIN INJ 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.1001, MedName = "VILMECTIN INJ 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.1002, MedName = "TAVILIN 200 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.1003, MedName = "TYLORATE INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1004, MedName = "OXYTETRAVEL 20 % INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1006, MedName = "TECTIN SUPER INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1007, MedName = "TECTIN INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1008, MedName = "BETAMOXIN INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1009, MedName = "TRISULFOPRIM INJ" });
                medNames.Add(new DAL.MedNames { MedID = 101.1010, MedName = "COLLSTIN 80" });
                medNames.Add(new DAL.MedNames { MedID = 101.1012, MedName = "kenosan 22kg tx" });
                medNames.Add(new DAL.MedNames { MedID = 101.1014, MedName = "VIROSEPT" });
                medNames.Add(new DAL.MedNames { MedID = 101.1015, MedName = "Coimyc -e Litre" });
                medNames.Add(new DAL.MedNames { MedID = 101.1016, MedName = "ALKALINET 20" });
                medNames.Add(new DAL.MedNames { MedID = 101.1017, MedName = "Cypertac 10% 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.1018, MedName = "Mycotivet" });
                medNames.Add(new DAL.MedNames { MedID = 101.1019, MedName = "Viruquat 240 5 liter" });
                medNames.Add(new DAL.MedNames { MedID = 101.1020, MedName = "HG-GEL-VAC 3" });
                medNames.Add(new DAL.MedNames { MedID = 101.1026, MedName = "SULFAVED" });
                medNames.Add(new DAL.MedNames { MedID = 101.1029, MedName = "هيدروجين بروكسيد H2 O2" });
                medNames.Add(new DAL.MedNames { MedID = 101.1030, MedName = "ايثانول" });
                medNames.Add(new DAL.MedNames { MedID = 101.1031, MedName = "Hemexol 1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.1032, MedName = "Virocid 20L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1033, MedName = "CIEAN CID 5L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1034, MedName = "SAVTIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.1035, MedName = "CLAUUCILLIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.1036, MedName = "Spectagen 5L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1037, MedName = "EX20 LT ORAL" });
                medNames.Add(new DAL.MedNames { MedID = 101.1038, MedName = "Savcoflo" });
                medNames.Add(new DAL.MedNames { MedID = 101.1039, MedName = "Formaldehyde" });
                medNames.Add(new DAL.MedNames { MedID = 101.104, MedName = "ENTEROCILLIN PLUS" });
                medNames.Add(new DAL.MedNames { MedID = 101.1040, MedName = "Elanco-clinafarm spray 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1041, MedName = "Fumite 100 gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.1042, MedName = "CIPROXINE 20-SUPER" });
                medNames.Add(new DAL.MedNames { MedID = 101.1043, MedName = "DICLACHEM 2.5%" });
                medNames.Add(new DAL.MedNames { MedID = 101.1044, MedName = "Aquaceat p.p" });
                medNames.Add(new DAL.MedNames { MedID = 101.1045, MedName = "DT FOAM" });
                medNames.Add(new DAL.MedNames { MedID = 101.1046, MedName = "EVALON + HIPRAMUNE T 1000s" });
                medNames.Add(new DAL.MedNames { MedID = 101.1047, MedName = "Vertacure" });
                medNames.Add(new DAL.MedNames { MedID = 101.1048, MedName = "Colisten aspa" });
                medNames.Add(new DAL.MedNames { MedID = 101.1049, MedName = "XL add on 25 L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1050, MedName = "فونيك مركز 1 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.1051, MedName = "ILT 2500 + Solvens o/n 2500" });
                medNames.Add(new DAL.MedNames { MedID = 101.1052, MedName = "Respiralmint Forte" });
                medNames.Add(new DAL.MedNames { MedID = 101.1053, MedName = "Herbatox forte" });
                medNames.Add(new DAL.MedNames { MedID = 101.1054, MedName = "BOEHRINGER-NEWXXITEK 4000 DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.1055, MedName = "BOEHRINGER-STER DILUENT VAXXITEK 800 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.1056, MedName = "BOEHRINGER-GALLIVAC BDA INJVI 8000 DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.1057, MedName = "MERIAL -GE 208 ND/FLU 0.3 ML FL 1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.1058, MedName = "MERIAL -MAREK BLUE DYE 20 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.1059, MedName = "Protect0x DW" });
                medNames.Add(new DAL.MedNames { MedID = 101.106, MedName = "erthromycin 500 avico" });
                medNames.Add(new DAL.MedNames { MedID = 101.1060, MedName = "Acipure" });
                medNames.Add(new DAL.MedNames { MedID = 101.1061, MedName = "Colireef" });
                medNames.Add(new DAL.MedNames { MedID = 101.1062, MedName = "Ultrafoam" });
                medNames.Add(new DAL.MedNames { MedID = 101.1063, MedName = "سوبيريور فونيك مركز 20 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.1066, MedName = "pharmasin 250g" });
                medNames.Add(new DAL.MedNames { MedID = 101.1067, MedName = "Aurofac 200 G" });
                medNames.Add(new DAL.MedNames { MedID = 101.1068, MedName = "Probiomax" });
                medNames.Add(new DAL.MedNames { MedID = 101.1069, MedName = "Brobait 0.005%" });
                medNames.Add(new DAL.MedNames { MedID = 101.1070, MedName = "Methavet" });
                medNames.Add(new DAL.MedNames { MedID = 101.1071, MedName = "تياموفيت سائل 1 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.1072, MedName = "ليفابان" });
                medNames.Add(new DAL.MedNames { MedID = 101.1073, MedName = "Germban terminator" });
                medNames.Add(new DAL.MedNames { MedID = 101.1074, MedName = "Hidrocol 1 lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.1075, MedName = "DELTAPHOS 1lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.1076, MedName = "Nefril" });
                medNames.Add(new DAL.MedNames { MedID = 101.1077, MedName = "Mintamixi plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.1078, MedName = "Evcoment plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.1079, MedName = "Hepamix Plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.1080, MedName = "Apravet 500mg" });
                medNames.Add(new DAL.MedNames { MedID = 101.1081, MedName = "Tilmovet 25%960 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.1082, MedName = "Omnicide 25l" });
                medNames.Add(new DAL.MedNames { MedID = 101.1083, MedName = "Doxiciclina 500mg/g" });
                medNames.Add(new DAL.MedNames { MedID = 101.1084, MedName = "الترافيت م" });
                medNames.Add(new DAL.MedNames { MedID = 101.1085, MedName = "Melofeed Drink" });
                medNames.Add(new DAL.MedNames { MedID = 101.1086, MedName = "HYDO PLUS" });
                medNames.Add(new DAL.MedNames { MedID = 101.1087, MedName = "Avico e+se 10%" });
                medNames.Add(new DAL.MedNames { MedID = 101.1088, MedName = "Mefluvac h9+nd" });
                medNames.Add(new DAL.MedNames { MedID = 101.1089, MedName = "Betavet" });
                medNames.Add(new DAL.MedNames { MedID = 101.1090, MedName = "Vetadel" });
                medNames.Add(new DAL.MedNames { MedID = 101.1091, MedName = "Ventacure" });
                medNames.Add(new DAL.MedNames { MedID = 101.1092, MedName = "EPADURE - ايباديور" });
                medNames.Add(new DAL.MedNames { MedID = 101.1093, MedName = "Elanco-avipro gumboro 5000 dose" });
                medNames.Add(new DAL.MedNames { MedID = 101.1094, MedName = "Flormac 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1095, MedName = "Aspa phos_col" });
                medNames.Add(new DAL.MedNames { MedID = 101.1096, MedName = "NEOHEPATOX 5L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1097, MedName = "Germban Terminator 1ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1098, MedName = "Toltavet 2.5% 1ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1099, MedName = "Respower 1ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1100, MedName = "An - Dine 5 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1101, MedName = "Penstrep 400" });
                medNames.Add(new DAL.MedNames { MedID = 101.1102, MedName = "مبيد زراعي خاص" });
                medNames.Add(new DAL.MedNames { MedID = 101.1103, MedName = "Target  Ap 91g" });
                medNames.Add(new DAL.MedNames { MedID = 101.111, MedName = "FC-4 Pasteurella Multocida Bactrin" });
                medNames.Add(new DAL.MedNames { MedID = 101.1169, MedName = "virokill 21.5" });
                medNames.Add(new DAL.MedNames { MedID = 101.1171, MedName = "innovx-nd 4000" });
                medNames.Add(new DAL.MedNames { MedID = 101.1172, MedName = "rismavac 2000 do" });
                medNames.Add(new DAL.MedNames { MedID = 101.1173, MedName = "selen-e l" });
                medNames.Add(new DAL.MedNames { MedID = 101.1174, MedName = "ultradox" });
                medNames.Add(new DAL.MedNames { MedID = 101.118, MedName = "FORMAGEN10KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.1200, MedName = "Dexid 5L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1201, MedName = "Dexid 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.1203, MedName = "sure clen 25 leter" });
                medNames.Add(new DAL.MedNames { MedID = 101.1204, MedName = "arsilvon" });
                medNames.Add(new DAL.MedNames { MedID = 101.1205, MedName = "ارتيفكس" });
                medNames.Add(new DAL.MedNames { MedID = 101.1206, MedName = "ارتيفكس" });
                medNames.Add(new DAL.MedNames { MedID = 101.1207, MedName = "vitameth ad3 5ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1208, MedName = "vitameth sel e 5ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.1209, MedName = "caustic soda flakes" });
                medNames.Add(new DAL.MedNames { MedID = 101.121, MedName = "Fumispore 300m" });
                medNames.Add(new DAL.MedNames { MedID = 101.1211, MedName = "NEOVIT E 20% + SEL + BIOTIN 5 L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1212, MedName = "NEOVIT AD3E FORTE 5 L" });
                medNames.Add(new DAL.MedNames { MedID = 101.1213, MedName = "B - ACT" });
                medNames.Add(new DAL.MedNames { MedID = 101.1214, MedName = "INTROVIT E+S" });
                medNames.Add(new DAL.MedNames { MedID = 101.1215, MedName = "RUMEX PLUS" });
                medNames.Add(new DAL.MedNames { MedID = 101.1216, MedName = "ملح انجليزي" });
                medNames.Add(new DAL.MedNames { MedID = 101.1217, MedName = "SANILIVER" });
                medNames.Add(new DAL.MedNames { MedID = 101.1218, MedName = "Rismavac 2000 ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.1219, MedName = "كفوف لاتيكس" });
                medNames.Add(new DAL.MedNames { MedID = 101.1220, MedName = "DOXYVAP" });
                medNames.Add(new DAL.MedNames { MedID = 101.1221, MedName = "افيكو جمبو فورت" });
                medNames.Add(new DAL.MedNames { MedID = 101.1222, MedName = "فيتامين هـ + س 10%" });
                medNames.Add(new DAL.MedNames { MedID = 101.1223, MedName = "STALLFORM" });
                medNames.Add(new DAL.MedNames { MedID = 101.1224, MedName = "Amproqunoxatne plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.1225, MedName = "vaxxon coryza 3" });
                medNames.Add(new DAL.MedNames { MedID = 101.124, MedName = "GENTADOX500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.136, MedName = "HIPRA clon- H120 2500doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.137, MedName = "HYDRODOXX 1 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.138, MedName = "ib 88 1000doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.141, MedName = "IB -PREMER 2500DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.142, MedName = "ib primer 5000doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.144, MedName = "IB4/9125000D" });
                medNames.Add(new DAL.MedNames { MedID = 101.147, MedName = "IB-MA5-2500DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.149, MedName = "INFLUENZA H9N2" });
                medNames.Add(new DAL.MedNames { MedID = 101.151, MedName = "IODIN 2.8- 5 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.153, MedName = "IZO ND-BROILER- ONLY 250ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.156, MedName = "Jovasalm-e 1000 dose" });
                medNames.Add(new DAL.MedNames { MedID = 101.158, MedName = "linco-spectin 100 150gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.159, MedName = "LINCOVED40%" });
                medNames.Add(new DAL.MedNames { MedID = 101.161, MedName = "LEVAMISOLE 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.163, MedName = "MA5+CLON301000D" });
                medNames.Add(new DAL.MedNames { MedID = 101.164, MedName = "MA5+CLON302500D" });
                medNames.Add(new DAL.MedNames { MedID = 101.165, MedName = "MAXI FORT 1 LETER" });
                medNames.Add(new DAL.MedNames { MedID = 101.172, MedName = "MUOCLEN-M 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.175, MedName = "ND clon 30 2500-DOZ INTERVET" });
                medNames.Add(new DAL.MedNames { MedID = 101.176, MedName = "NDclon 30 1000DOZ INTERVET" });
                medNames.Add(new DAL.MedNames { MedID = 101.177, MedName = "NEEDL" });
                medNames.Add(new DAL.MedNames { MedID = 101.178, MedName = "NEOMIN PLUS-500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.185, MedName = "Nuflor100ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.187, MedName = "octacillINA500gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.188, MedName = "OXIVITAMIN-1KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.189, MedName = "OXYCOL500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.196, MedName = "PROVI-ACTIV500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.198, MedName = "PROVI-FLOR20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.199, MedName = "PROVI-HAVISIED500GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.206, MedName = "PROVI-TOLTRA" });
                medNames.Add(new DAL.MedNames { MedID = 101.211, MedName = "SHS hipra" });
                medNames.Add(new DAL.MedNames { MedID = 101.212, MedName = "SOGECOL 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.214, MedName = "Soludox" });
                medNames.Add(new DAL.MedNames { MedID = 101.217, MedName = "spray-vac1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.219, MedName = "STAREDOXYCOL" });
                medNames.Add(new DAL.MedNames { MedID = 101.223, MedName = "TELMOVET 25% 250 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.225, MedName = "TERMONATER1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.226, MedName = "TILMODAD 240 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.229, MedName = "TYLOSIN-AVIVO100GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.232, MedName = "UNIVEX1000DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.233, MedName = "VAC-BAC PLUS" });
                medNames.Add(new DAL.MedNames { MedID = 101.235, MedName = "VECTORMUNE FP-MG+AE" });
                medNames.Add(new DAL.MedNames { MedID = 101.237, MedName = "vetacox s 100gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.239, MedName = "VIT.AD3E L1" });
                medNames.Add(new DAL.MedNames { MedID = 101.240, MedName = "VIT.K 12.5% avico" });
                medNames.Add(new DAL.MedNames { MedID = 101.243, MedName = "Vitamin c 25% kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.245, MedName = "VITOCOLI 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.249, MedName = "اسرنج اوتوماتيك" });
                medNames.Add(new DAL.MedNames { MedID = 101.254, MedName = "EXCINIEL 4 Gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.256, MedName = "Flobenal" });
                medNames.Add(new DAL.MedNames { MedID = 101.257, MedName = "Maxivet pluse 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.259, MedName = "VOLVAC ND+IB" });
                medNames.Add(new DAL.MedNames { MedID = 101.260, MedName = "LAR - VAC ILT 1000 DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.261, MedName = "VITAMIN K 12.5% VAPCO" });
                medNames.Add(new DAL.MedNames { MedID = 101.266, MedName = "amoxystin 1 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.267, MedName = "amoxi - 50 sp" });
                medNames.Add(new DAL.MedNames { MedID = 101.270, MedName = "doxy brim 1 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.271, MedName = "Biosolvet 2% 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.272, MedName = "Telmicoved" });
                medNames.Add(new DAL.MedNames { MedID = 101.273, MedName = "IB OLVAC 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.275, MedName = "Hipra Clon 2500 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.277, MedName = "ND BROLLER 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.279, MedName = "Oven 9 k 5 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.280, MedName = "BC BLADE" });
                medNames.Add(new DAL.MedNames { MedID = 101.282, MedName = "Newcastle nd las" });
                medNames.Add(new DAL.MedNames { MedID = 101.286, MedName = "AI - VAC H 9" });
                medNames.Add(new DAL.MedNames { MedID = 101.289, MedName = "IB + ND + G + REO 500ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.290, MedName = "SALENVAC-T 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.291, MedName = "Dio Sol Slit" });
                medNames.Add(new DAL.MedNames { MedID = 101.301, MedName = "AVIPRO 201 AB/ND 1000 DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.302, MedName = "CUSTOVAC D PLUS 250 GM" });
                medNames.Add(new DAL.MedNames { MedID = 101.306, MedName = "JOVAC 9R 1000 DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.307, MedName = "G - OLVAC" });
                medNames.Add(new DAL.MedNames { MedID = 101.308, MedName = "ONE DAY OLVAC" });
                medNames.Add(new DAL.MedNames { MedID = 101.309, MedName = "Gollivec AE+FP 1000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.317, MedName = "ND K VI NU CHICK VACC. DAY OLD" });
                medNames.Add(new DAL.MedNames { MedID = 101.318, MedName = "HSW UNI-MATIC 1M HENKE SASS" });
                medNames.Add(new DAL.MedNames { MedID = 101.319, MedName = "NEEDLES HSW HENKE SASS" });
                medNames.Add(new DAL.MedNames { MedID = 101.320, MedName = "VIGOSINE" });
                medNames.Add(new DAL.MedNames { MedID = 101.321, MedName = "formalen" });
                medNames.Add(new DAL.MedNames { MedID = 101.323, MedName = "HIPRAVIAR ND BROILERS 2500DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.325, MedName = "CEFRILOS - P 1 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.326, MedName = "NEOVIT E 20%+SE+BIOTIN 5 L" });
                medNames.Add(new DAL.MedNames { MedID = 101.332, MedName = "IDOCLEAN" });
                medNames.Add(new DAL.MedNames { MedID = 101.335, MedName = "MENTOFIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.336, MedName = "GALLIMUNE FI4 H9 M.E 300 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.337, MedName = "GALLIMUNE 407 ND+IB+EDS+ART 300 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.340, MedName = "STERIFUM" });
                medNames.Add(new DAL.MedNames { MedID = 101.362, MedName = "CHLORACINE 1 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.365, MedName = "fosfodad 1 L" });
                medNames.Add(new DAL.MedNames { MedID = 101.367, MedName = "murdex" });
                medNames.Add(new DAL.MedNames { MedID = 101.369, MedName = "normal saline 2000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.372, MedName = "avipro nd lasota" });
                medNames.Add(new DAL.MedNames { MedID = 101.375, MedName = "B - MAX" });
                medNames.Add(new DAL.MedNames { MedID = 101.376, MedName = "ACETIC ACID 30 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.377, MedName = "OMINICIDE FG 11" });
                medNames.Add(new DAL.MedNames { MedID = 101.381, MedName = "TILMICOX" });
                medNames.Add(new DAL.MedNames { MedID = 101.384, MedName = "DOXY OXY DAD" });
                medNames.Add(new DAL.MedNames { MedID = 101.389, MedName = "ASPI - C" });
                medNames.Add(new DAL.MedNames { MedID = 101.390, MedName = "Diluent fd 200 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.392, MedName = "COLISOL 250 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.393, MedName = "AMPICILLIN 20% AVECO" });
                medNames.Add(new DAL.MedNames { MedID = 101.394, MedName = "ampicin 1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.398, MedName = "CEPNADAD 20% 1KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.400, MedName = "amprosol" });
                medNames.Add(new DAL.MedNames { MedID = 101.403, MedName = "NEOCIN 20% 500 G" });
                medNames.Add(new DAL.MedNames { MedID = 101.404, MedName = "VIT E+SEL 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.405, MedName = "TYLODAD 100 500 G" });
                medNames.Add(new DAL.MedNames { MedID = 101.409, MedName = "multi des" });
                medNames.Add(new DAL.MedNames { MedID = 101.411, MedName = "colin - l" });
                medNames.Add(new DAL.MedNames { MedID = 101.415, MedName = "cline farm smoke" });
                medNames.Add(new DAL.MedNames { MedID = 101.416, MedName = "cline farm sprey" });
                medNames.Add(new DAL.MedNames { MedID = 101.418, MedName = "coliprim 100 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.419, MedName = "avi pro gumboro lyo intermediate" });
                medNames.Add(new DAL.MedNames { MedID = 101.426, MedName = "flumin 20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.435, MedName = "fungizal 1 ltrl" });
                medNames.Add(new DAL.MedNames { MedID = 101.436, MedName = "formaclean" });
                medNames.Add(new DAL.MedNames { MedID = 101.439, MedName = "fosbac + t 5 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.440, MedName = "respicare plus 1 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.443, MedName = "NEMOVAC 1000 DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.445, MedName = "despadac 5 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.447, MedName = "CEVAC FLU H 9" });
                medNames.Add(new DAL.MedNames { MedID = 101.449, MedName = "VOLVAC ND 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.450, MedName = "VMD - LINCOMYCIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.458, MedName = "TERMINATOR 5 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.461, MedName = "tylorate 500g" });
                medNames.Add(new DAL.MedNames { MedID = 101.462, MedName = "ACTIVATOR 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.464, MedName = "سرنجات 3 مل" });
                medNames.Add(new DAL.MedNames { MedID = 101.467, MedName = "TH+4 5LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.469, MedName = "CHLORTETRACYCLIN SPRAY" });
                medNames.Add(new DAL.MedNames { MedID = 101.477, MedName = "REO LIVE + DILUENT" });
                medNames.Add(new DAL.MedNames { MedID = 101.478, MedName = "E - FLOX 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.479, MedName = "SULFADIARIN - S" });
                medNames.Add(new DAL.MedNames { MedID = 101.481, MedName = "BLACK DIS 1+3 20 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.483, MedName = "water sprayer" });
                medNames.Add(new DAL.MedNames { MedID = 101.484, MedName = "jovazet 7 300 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.487, MedName = "diclacox liquid 500 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.488, MedName = "CG - HERBS 1LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.490, MedName = "HEMEXOL 5 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.493, MedName = "ROXYCOL ORAL SOLUTION 1 LT" });
                medNames.Add(new DAL.MedNames { MedID = 101.494, MedName = "VIT C 50%" });
                medNames.Add(new DAL.MedNames { MedID = 101.495, MedName = "VEGGISAN" });
                medNames.Add(new DAL.MedNames { MedID = 101.498, MedName = "ميزان حرارة" });
                medNames.Add(new DAL.MedNames { MedID = 101.499, MedName = "STRESSEN" });
                medNames.Add(new DAL.MedNames { MedID = 101.500, MedName = "LEVITAN" });
                medNames.Add(new DAL.MedNames { MedID = 101.501, MedName = "hyj iodine" });
                medNames.Add(new DAL.MedNames { MedID = 101.502, MedName = "diazinon" });
                medNames.Add(new DAL.MedNames { MedID = 101.505, MedName = "amoxystin 500 gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.507, MedName = "volvac nd lasota 1000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.509, MedName = "AGITA" });
                medNames.Add(new DAL.MedNames { MedID = 101.511, MedName = "Fumispore 2500m" });
                medNames.Add(new DAL.MedNames { MedID = 101.512, MedName = "Fumispore 5m" });
                medNames.Add(new DAL.MedNames { MedID = 101.513, MedName = "antigermen fort" });
                medNames.Add(new DAL.MedNames { MedID = 101.516, MedName = "AVI BLUE" });
                medNames.Add(new DAL.MedNames { MedID = 101.519, MedName = "Reo 1133 1000 + diluent" });
                medNames.Add(new DAL.MedNames { MedID = 101.520, MedName = "ND BROILER 2000 DOZ" });
                medNames.Add(new DAL.MedNames { MedID = 101.521, MedName = "HEPATODOX 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.523, MedName = "VOLVAC IBD MLV" });
                medNames.Add(new DAL.MedNames { MedID = 101.524, MedName = "avitryl 100 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.526, MedName = "GPC8" });
                medNames.Add(new DAL.MedNames { MedID = 101.528, MedName = "PEN STREP INJ 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.530, MedName = "ULTRASNAP TESTING KIT" });
                medNames.Add(new DAL.MedNames { MedID = 101.532, MedName = "vapcotrim" });
                medNames.Add(new DAL.MedNames { MedID = 101.533, MedName = "AL DEKOL DES FF" });
                medNames.Add(new DAL.MedNames { MedID = 101.534, MedName = "AL DEKOL DES 03" });
                medNames.Add(new DAL.MedNames { MedID = 101.537, MedName = "GBC 8 25 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.539, MedName = "ERUTHRATE  20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.540, MedName = "ERUTHRATE  35% 1/2kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.544, MedName = "vmd-gentaveto-5" });
                medNames.Add(new DAL.MedNames { MedID = 101.545, MedName = "haemomax 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.546, MedName = "enrotrill" });
                medNames.Add(new DAL.MedNames { MedID = 101.547, MedName = "tylorate 83.33%1k" });
                medNames.Add(new DAL.MedNames { MedID = 101.548, MedName = "flonicol 10% " });
                medNames.Add(new DAL.MedNames { MedID = 101.550, MedName = "Enrol 20% 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.551, MedName = "spectra colisol 1 lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.552, MedName = "OLVAC B+6+R" });
                medNames.Add(new DAL.MedNames { MedID = 101.553, MedName = "GALLOVAC 9R 1000 DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.555, MedName = "mobebron plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.556, MedName = "hipraviar-s /h120 1000ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.558, MedName = "ampicin 500gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.562, MedName = "chick paper" });
                medNames.Add(new DAL.MedNames { MedID = 101.563, MedName = "enrovet 10%" });
                medNames.Add(new DAL.MedNames { MedID = 101.564, MedName = "shift 25 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.566, MedName = "eds - 500vac" });
                medNames.Add(new DAL.MedNames { MedID = 101.567, MedName = "amprolium 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.568, MedName = "iba-vac 1000doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.569, MedName = "fosfo land liter" });
                medNames.Add(new DAL.MedNames { MedID = 101.571, MedName = "immucox 1000dos" });
                medNames.Add(new DAL.MedNames { MedID = 101.576, MedName = "Tylosin Avico 500gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.580, MedName = "volvac nd +ib+eds 500ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.581, MedName = "neocol 1 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.583, MedName = "ILT 1000 INTERVET" });
                medNames.Add(new DAL.MedNames { MedID = 101.584, MedName = "NOFAR-1KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.585, MedName = "MYCOPLASMIN" });
                medNames.Add(new DAL.MedNames { MedID = 101.586, MedName = "shift 5 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.588, MedName = "افرهول" });
                medNames.Add(new DAL.MedNames { MedID = 101.589, MedName = "Aqua Clean 10 lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.591, MedName = "apramycin 100 gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.593, MedName = "biosolve plus" });
                medNames.Add(new DAL.MedNames { MedID = 101.594, MedName = "maskomal" });
                medNames.Add(new DAL.MedNames { MedID = 101.595, MedName = "ACTIVO LIQUID 1 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.598, MedName = "سرنجات 5 مل" });
                medNames.Add(new DAL.MedNames { MedID = 101.599, MedName = "Diclacev 1lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.600, MedName = "Q-Chem Viruquat 240 25liter" });
                medNames.Add(new DAL.MedNames { MedID = 101.601, MedName = "goldben" });
                medNames.Add(new DAL.MedNames { MedID = 101.603, MedName = "BRAMHEXINE 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.604, MedName = "PROCOL-20 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.605, MedName = "CYPERMETHRIN-10% VET" });
                medNames.Add(new DAL.MedNames { MedID = 101.606, MedName = "Agrigerm 5 lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.607, MedName = "abreuval tabelts" });
                medNames.Add(new DAL.MedNames { MedID = 101.608, MedName = "virkon lsp2%" });
                medNames.Add(new DAL.MedNames { MedID = 101.611, MedName = "FLORFENICOL-AR 1 LIT" });
                medNames.Add(new DAL.MedNames { MedID = 101.616, MedName = "CID 2000 10 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.617, MedName = "nd ib vac 1000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.618, MedName = "phoxim 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.624, MedName = "ERUTHRATE  35% 1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.626, MedName = "miarom liquid 250 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.627, MedName = "ampicid" });
                medNames.Add(new DAL.MedNames { MedID = 101.629, MedName = "izovac nd-flu" });
                medNames.Add(new DAL.MedNames { MedID = 101.632, MedName = "cevac broiler nd k" });
                medNames.Add(new DAL.MedNames { MedID = 101.633, MedName = "mentho land 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.634, MedName = "diclosol 1l" });
                medNames.Add(new DAL.MedNames { MedID = 101.635, MedName = "flu penol" });
                medNames.Add(new DAL.MedNames { MedID = 101.636, MedName = "جنزاره شوال" });
                medNames.Add(new DAL.MedNames { MedID = 101.637, MedName = "dexamol" });
                medNames.Add(new DAL.MedNames { MedID = 101.638, MedName = "tmla" });
                medNames.Add(new DAL.MedNames { MedID = 101.640, MedName = "ورق صوص" });
                medNames.Add(new DAL.MedNames { MedID = 101.641, MedName = "q-chem viroxide super 5 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.648, MedName = "mucolin" });
                medNames.Add(new DAL.MedNames { MedID = 101.649, MedName = "latex gloves" });
                medNames.Add(new DAL.MedNames { MedID = 101.650, MedName = "cpe shoes cover 4g" });
                medNames.Add(new DAL.MedNames { MedID = 101.651, MedName = "overall with cap & shoes" });
                medNames.Add(new DAL.MedNames { MedID = 101.654, MedName = "vit E + SE" });
                medNames.Add(new DAL.MedNames { MedID = 101.656, MedName = "VIRKON S 10 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.657, MedName = "AVIFLOR 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.661, MedName = "ramaj gel" });
                medNames.Add(new DAL.MedNames { MedID = 101.662, MedName = "اتوماتيك مشرب" });
                medNames.Add(new DAL.MedNames { MedID = 101.663, MedName = "Ecodiar liq.1lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.664, MedName = "CAV P4 1000+Diluent" });
                medNames.Add(new DAL.MedNames { MedID = 101.666, MedName = "EURO VIT K3 20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.670, MedName = "amoxi ndoxal" });
                medNames.Add(new DAL.MedNames { MedID = 101.671, MedName = "makrovil oral 480ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.672, MedName = "Reo - vac" });
                medNames.Add(new DAL.MedNames { MedID = 101.674, MedName = "izovac ilt 1000 dos" });
                medNames.Add(new DAL.MedNames { MedID = 101.676, MedName = "black dis 1+3 (200kg برميل" });
                medNames.Add(new DAL.MedNames { MedID = 101.677, MedName = "e+se دوكسال" });
                medNames.Add(new DAL.MedNames { MedID = 101.678, MedName = "DOXOLAX GR 450" });
                medNames.Add(new DAL.MedNames { MedID = 101.679, MedName = "sc boost liquid" });
                medNames.Add(new DAL.MedNames { MedID = 101.689, MedName = "bromovam 20.40" });
                medNames.Add(new DAL.MedNames { MedID = 101.691, MedName = "GRIPPOZON" });
                medNames.Add(new DAL.MedNames { MedID = 101.692, MedName = "fosfin 20% ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.694, MedName = "DELTAPHOS 5 l" });
                medNames.Add(new DAL.MedNames { MedID = 101.695, MedName = "fordox 500g" });
                medNames.Add(new DAL.MedNames { MedID = 101.696, MedName = "cevac ibird l2500ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.701, MedName = "ايفلوسين" });
                medNames.Add(new DAL.MedNames { MedID = 101.702, MedName = "amprol 60%" });
                medNames.Add(new DAL.MedNames { MedID = 101.703, MedName = "idd target" });
                medNames.Add(new DAL.MedNames { MedID = 101.706, MedName = "gumboro d782500" });
                medNames.Add(new DAL.MedNames { MedID = 101.707, MedName = "biojector iv -11" });
                medNames.Add(new DAL.MedNames { MedID = 101.712, MedName = "izovac aviflu 1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.713, MedName = "ad13 anichem30kq-25ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.719, MedName = "th5 10 liter" });
                medNames.Add(new DAL.MedNames { MedID = 101.722, MedName = "lincocev 5 k" });
                medNames.Add(new DAL.MedNames { MedID = 101.727, MedName = "persect-25% wp 1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.728, MedName = "jovazeit 7 / 1000d 300ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.729, MedName = "fumagri 25-50" });
                medNames.Add(new DAL.MedNames { MedID = 101.730, MedName = "persect-25wp 100gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.731, MedName = "normal saline dil 200 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.732, MedName = "izo vac clone 2500d" });
                medNames.Add(new DAL.MedNames { MedID = 101.733, MedName = "hi -7" });
                medNames.Add(new DAL.MedNames { MedID = 101.734, MedName = "normal salin" });
                medNames.Add(new DAL.MedNames { MedID = 101.735, MedName = "ميغالون باستيا" });
                medNames.Add(new DAL.MedNames { MedID = 101.737, MedName = "hydraxin" });
                medNames.Add(new DAL.MedNames { MedID = 101.738, MedName = "1231-provilan 550 g" });
                medNames.Add(new DAL.MedNames { MedID = 101.739, MedName = "acidex food b23  5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.740, MedName = "acedex fg/cid120 5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.741, MedName = "acedex deep clen 5 l" });
                medNames.Add(new DAL.MedNames { MedID = 101.742, MedName = "acedx dex20  5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.743, MedName = "acedx fg 80  5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.744, MedName = "acedx foxigen" });
                medNames.Add(new DAL.MedNames { MedID = 101.745, MedName = "fastec new orange" });
                medNames.Add(new DAL.MedNames { MedID = 101.746, MedName = "kh baldes" });
                medNames.Add(new DAL.MedNames { MedID = 101.748, MedName = "doxy sol 50l-doxal" });
                medNames.Add(new DAL.MedNames { MedID = 101.749, MedName = "Clone30 5000" });
                medNames.Add(new DAL.MedNames { MedID = 101.751, MedName = "virkon isp 20l" });
                medNames.Add(new DAL.MedNames { MedID = 101.752, MedName = "fumpro" });
                medNames.Add(new DAL.MedNames { MedID = 101.754, MedName = "volvac nd lasota 2000 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.755, MedName = "thymovac 2500 doz" });
                medNames.Add(new DAL.MedNames { MedID = 101.756, MedName = "avigo 108 fc b platinum2000" });
                medNames.Add(new DAL.MedNames { MedID = 101.757, MedName = "midchm f08 20 liter" });
                medNames.Add(new DAL.MedNames { MedID = 101.759, MedName = "bio-san لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.760, MedName = "cid 20 25 l" });
                medNames.Add(new DAL.MedNames { MedID = 101.762, MedName = "n b d-99-5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.765, MedName = "pulmomix" });
                medNames.Add(new DAL.MedNames { MedID = 101.766, MedName = "cermosan 5 lyter" });
                medNames.Add(new DAL.MedNames { MedID = 101.767, MedName = "cleanosm25 k" });
                medNames.Add(new DAL.MedNames { MedID = 101.768, MedName = "يود 5لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.769, MedName = "zovac gumboro 3" });
                medNames.Add(new DAL.MedNames { MedID = 101.770, MedName = "elanco-flubenol premix 1 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.771, MedName = "Aifcid 20g" });
                medNames.Add(new DAL.MedNames { MedID = 101.772, MedName = "elanco-avipro aviblue bott" });
                medNames.Add(new DAL.MedNames { MedID = 101.775, MedName = "aftovac-111/300 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.777, MedName = "flonicol extra 20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.780, MedName = "فيركونات" });
                medNames.Add(new DAL.MedNames { MedID = 101.781, MedName = "gallimune208" });
                medNames.Add(new DAL.MedNames { MedID = 101.782, MedName = "nuflor 50 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.784, MedName = "DUPHALYTE" });
                medNames.Add(new DAL.MedNames { MedID = 101.785, MedName = "antec-blosolve 20ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.786, MedName = "elanco-avipro precise 5000 dose" });
                medNames.Add(new DAL.MedNames { MedID = 101.787, MedName = "izovac reo live+diluent(doses1000)m" });
                medNames.Add(new DAL.MedNames { MedID = 101.788, MedName = "gelumunt se+s 300 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.789, MedName = "self-refilling twin" });
                medNames.Add(new DAL.MedNames { MedID = 101.790, MedName = "fumagri i250-2500" });
                medNames.Add(new DAL.MedNames { MedID = 101.791, MedName = "sure clen 5 leter" });
                medNames.Add(new DAL.MedNames { MedID = 101.792, MedName = "cleno san" });
                medNames.Add(new DAL.MedNames { MedID = 101.793, MedName = "ricoden/ السبيل" });
                medNames.Add(new DAL.MedNames { MedID = 101.794, MedName = "Soluphose" });
                medNames.Add(new DAL.MedNames { MedID = 101.795, MedName = "gentavex" });
                medNames.Add(new DAL.MedNames { MedID = 101.796, MedName = "flonicol 20% " });
                medNames.Add(new DAL.MedNames { MedID = 101.797, MedName = "مرشات مزارع" });
                medNames.Add(new DAL.MedNames { MedID = 101.798, MedName = "scarup 16 g" });
                medNames.Add(new DAL.MedNames { MedID = 101.800, MedName = "digestsea1010" });
                medNames.Add(new DAL.MedNames { MedID = 101.804, MedName = "bio life plus 250 ml" });
                medNames.Add(new DAL.MedNames { MedID = 101.808, MedName = "degneasen with chlorin 10kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.809, MedName = "detergent with chlorin 25l" });
                medNames.Add(new DAL.MedNames { MedID = 101.810, MedName = "chlorin tab" });
                medNames.Add(new DAL.MedNames { MedID = 101.811, MedName = "erythrate 20%1kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.812, MedName = "Elanco-Tylan premix 250 25kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.815, MedName = "aminovet" });
                medNames.Add(new DAL.MedNames { MedID = 101.818, MedName = "enrosol 20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.819, MedName = "forme cleone" });
                medNames.Add(new DAL.MedNames { MedID = 101.820, MedName = "plus breathe" });
                medNames.Add(new DAL.MedNames { MedID = 101.823, MedName = "purTyl 100 g" });
                medNames.Add(new DAL.MedNames { MedID = 101.824, MedName = "savcoxain" });
                medNames.Add(new DAL.MedNames { MedID = 101.825, MedName = "Fastetio din58 5l" });
                medNames.Add(new DAL.MedNames { MedID = 101.828, MedName = "Quinovet-f-liq" });
                medNames.Add(new DAL.MedNames { MedID = 101.830, MedName = "vectornue HVT ND 4000 ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.831, MedName = "Cevac Transmune 4000 ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.832, MedName = "fosfin 20%250ml " });
                medNames.Add(new DAL.MedNames { MedID = 101.834, MedName = "prophyl" });
                medNames.Add(new DAL.MedNames { MedID = 101.836, MedName = "nbd-99 1lit" });
                medNames.Add(new DAL.MedNames { MedID = 101.843, MedName = "IODO-STAR" });
                medNames.Add(new DAL.MedNames { MedID = 101.844, MedName = "افيفلور سائل" });
                medNames.Add(new DAL.MedNames { MedID = 101.845, MedName = "افي ديور" });
                medNames.Add(new DAL.MedNames { MedID = 101.846, MedName = "hepavet ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.847, MedName = "ae+pox1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.848, MedName = "ميزان حرارة خشب 20 سم" });
                medNames.Add(new DAL.MedNames { MedID = 101.849, MedName = "florfenicol 20%" });
                medNames.Add(new DAL.MedNames { MedID = 101.850, MedName = "adiflox-30" });
                medNames.Add(new DAL.MedNames { MedID = 101.851, MedName = "dawis poutty spray" });
                medNames.Add(new DAL.MedNames { MedID = 101.854, MedName = "Avisan secure 1000ds (500ml)" });
                medNames.Add(new DAL.MedNames { MedID = 101.855, MedName = "elanco-avepro precise1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.858, MedName = "spectovet 100" });
                medNames.Add(new DAL.MedNames { MedID = 101.859, MedName = "cevac corymune 4k" });
                medNames.Add(new DAL.MedNames { MedID = 101.860, MedName = "COLISOL" });
                medNames.Add(new DAL.MedNames { MedID = 101.861, MedName = "GENTAVET 10%" });
                medNames.Add(new DAL.MedNames { MedID = 101.862, MedName = "cresolox200 k" });
                medNames.Add(new DAL.MedNames { MedID = 101.865, MedName = "perkill  kq" });
                medNames.Add(new DAL.MedNames { MedID = 101.866, MedName = "بربيش مشرب" });
                medNames.Add(new DAL.MedNames { MedID = 101.869, MedName = "elanco-avipro105 nd5000" });
                medNames.Add(new DAL.MedNames { MedID = 101.870, MedName = "doxycyclin 50%" });
                medNames.Add(new DAL.MedNames { MedID = 101.880, MedName = "leuco bf" });
                medNames.Add(new DAL.MedNames { MedID = 101.881, MedName = "avtevida 70 gm" });
                medNames.Add(new DAL.MedNames { MedID = 101.882, MedName = "clip cap blu" });
                medNames.Add(new DAL.MedNames { MedID = 101.883, MedName = "ampisin 20% 100g" });
                medNames.Add(new DAL.MedNames { MedID = 101.889, MedName = "اَبي - 20 منظف عام 30 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.890, MedName = "erythro 20% 500" });
                medNames.Add(new DAL.MedNames { MedID = 101.892, MedName = "arbocel rc fine" });
                medNames.Add(new DAL.MedNames { MedID = 101.893, MedName = "fumisure 4x" });
                medNames.Add(new DAL.MedNames { MedID = 101.895, MedName = "NOFAR-3" });
                medNames.Add(new DAL.MedNames { MedID = 101.896, MedName = "Cresolox Black Disinfeciont 5/F" });
                medNames.Add(new DAL.MedNames { MedID = 101.898, MedName = "Fostal" });
                medNames.Add(new DAL.MedNames { MedID = 101.899, MedName = "Eritro micin 20% Dox-al 500g" });
                medNames.Add(new DAL.MedNames { MedID = 101.900, MedName = "فونيك مركز 200لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.901, MedName = "فونيك 20 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.902, MedName = "كلو -6 مبيض جالون 3.5 لتر 4*1" });
                medNames.Add(new DAL.MedNames { MedID = 101.903, MedName = "يوكلين كلاش مزيل تكلس مراحيض جالون 3.58" });
                medNames.Add(new DAL.MedNames { MedID = 101.904, MedName = "كلين بيت صراصير" });
                medNames.Add(new DAL.MedNames { MedID = 101.910, MedName = "cevac transmune2000d" });
                medNames.Add(new DAL.MedNames { MedID = 101.911, MedName = "elanco-clinafarm spray1 lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.913, MedName = "verex 10 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.914, MedName = "viroguand 25 leter" });
                medNames.Add(new DAL.MedNames { MedID = 101.915, MedName = "AROMAX" });
                medNames.Add(new DAL.MedNames { MedID = 101.916, MedName = "ANTEC-AMBICIDE 20 LTR" });
                medNames.Add(new DAL.MedNames { MedID = 101.917, MedName = "ELANCO-CLINAFARM SMOKE" });
                medNames.Add(new DAL.MedNames { MedID = 101.918, MedName = "Encefal-vac" });
                medNames.Add(new DAL.MedNames { MedID = 101.920, MedName = "savcocx" });
                medNames.Add(new DAL.MedNames { MedID = 101.921, MedName = "INFLUENZA H9N2+ND" });
                medNames.Add(new DAL.MedNames { MedID = 101.922, MedName = "GENTO - 100" });
                medNames.Add(new DAL.MedNames { MedID = 101.923, MedName = "ELANCO-AVIPRO THMOVAC 2500 DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.924, MedName = "CEVAC NEW FLU H9 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.925, MedName = "coccivac - d 1000" });
                medNames.Add(new DAL.MedNames { MedID = 101.928, MedName = "anticox 1/2 ltr" });
                medNames.Add(new DAL.MedNames { MedID = 101.929, MedName = "Fumite 1 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.930, MedName = "Aquasnap Total Testing kit" });
                medNames.Add(new DAL.MedNames { MedID = 101.931, MedName = "ViruKill 260 فونيك" });
                medNames.Add(new DAL.MedNames { MedID = 101.933, MedName = "Izovac Nd-Ib-Ibd-Reo" });
                medNames.Add(new DAL.MedNames { MedID = 101.935, MedName = "murin" });
                medNames.Add(new DAL.MedNames { MedID = 101.937, MedName = "diacidol 60mc (w/v) bottles 1lit co-ex" });
                medNames.Add(new DAL.MedNames { MedID = 101.938, MedName = "ELANCO-AVIPRO 101 CORYZA 1000 DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.939, MedName = "MERIAL-VOLVAC ND CONC . KV 500 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.940, MedName = "DM CID S 24 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.941, MedName = "يوكلين منظف عام بي سطل 30لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.943, MedName = "ELANCO-AVIPRO ND-IB SOHOL 2500  DOSE" });
                medNames.Add(new DAL.MedNames { MedID = 101.944, MedName = "bronhifit 1 letr" });
                medNames.Add(new DAL.MedNames { MedID = 101.946, MedName = "savcotil" });
                medNames.Add(new DAL.MedNames { MedID = 101.947, MedName = "h2o2" });
                medNames.Add(new DAL.MedNames { MedID = 101.948, MedName = "لينكوسبكتين 880 /4.5كغم" });
                medNames.Add(new DAL.MedNames { MedID = 101.949, MedName = "fom19t-12788" });
                medNames.Add(new DAL.MedNames { MedID = 101.950, MedName = "desinfect gutar active-15073" });
                medNames.Add(new DAL.MedNames { MedID = 101.951, MedName = "cevac corymune 7k" });
                medNames.Add(new DAL.MedNames { MedID = 101.952, MedName = "doxyvet 20% Kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.954, MedName = "COLISTIN-80 VH12" });
                medNames.Add(new DAL.MedNames { MedID = 101.955, MedName = "BIOSLVET 0.5%" });
                medNames.Add(new DAL.MedNames { MedID = 101.956, MedName = "jovazeit - 1 FORT 2500 DOSE " });
                medNames.Add(new DAL.MedNames { MedID = 101.957, MedName = "Fumite 20G" });
                medNames.Add(new DAL.MedNames { MedID = 101.960, MedName = "NOVO BIOTIC" });
                medNames.Add(new DAL.MedNames { MedID = 101.961, MedName = "بخاخات" });
                medNames.Add(new DAL.MedNames { MedID = 101.962, MedName = "VECTURMUNE HVT-NDV 2000D" });
                medNames.Add(new DAL.MedNames { MedID = 101.963, MedName = "Lzovac Lasota 1000 Ds" });
                medNames.Add(new DAL.MedNames { MedID = 101.964, MedName = "poulvac ib primer 5000" });
                medNames.Add(new DAL.MedNames { MedID = 101.965, MedName = "KENOVIT E 1L NT" });
                medNames.Add(new DAL.MedNames { MedID = 101.967, MedName = "omniclean 25Lt" });
                medNames.Add(new DAL.MedNames { MedID = 101.968, MedName = "FACA MASK 3 PLY EAR LOOP" });
                medNames.Add(new DAL.MedNames { MedID = 101.969, MedName = "vectormune nd 1000 d" });
                medNames.Add(new DAL.MedNames { MedID = 101.970, MedName = "ELANCO - VIRUSNIP 5 KG" });
                medNames.Add(new DAL.MedNames { MedID = 101.973, MedName = "accent 4gm-1012-1814" });
                medNames.Add(new DAL.MedNames { MedID = 101.975, MedName = "Lzo Vac H120-Clonc 2500D" });
                medNames.Add(new DAL.MedNames { MedID = 101.976, MedName = "Imnnofarm Lia 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.977, MedName = "ميزان حرارة و رطوبة ديجتال صيني" });
                medNames.Add(new DAL.MedNames { MedID = 101.980, MedName = "Chlorine 5 kg" });
                medNames.Add(new DAL.MedNames { MedID = 101.981, MedName = "فلاش منظف حمامات 30 لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.984, MedName = "فيتامين K  500غ" });
                medNames.Add(new DAL.MedNames { MedID = 101.985, MedName = "بروفي دوكس 50% 200غ" });
                medNames.Add(new DAL.MedNames { MedID = 101.988, MedName = "EVALON - HIPRAMUNE T 5000s" });
                medNames.Add(new DAL.MedNames { MedID = 101.990, MedName = "CENFLOX 200 MG / ML 1L" });
                medNames.Add(new DAL.MedNames { MedID = 101.991, MedName = "Apsa Mint" });
                medNames.Add(new DAL.MedNames { MedID = 101.993, MedName = "فنجيزال سائل 1لتر" });
                medNames.Add(new DAL.MedNames { MedID = 101.995, MedName = "VITACEN AD3E INJ 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.996, MedName = "MULTIJECT 1 MM" });
                medNames.Add(new DAL.MedNames { MedID = 101.997, MedName = "ALAMYCIN LA 100 ML" });
                medNames.Add(new DAL.MedNames { MedID = 101.998, MedName = "NOROMECTIN  ML5" });
                medNames.Add(new DAL.MedNames { MedID = 101.999, MedName = "ALAMYCIN L/A 300 100 ML" });

                return medNames;

            } 
        }

        
    }
}
