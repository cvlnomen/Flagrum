﻿using System.Collections.Generic;
using Flagrum.Core.Gfxbin.Gmdl.Components;

namespace Flagrum.Core.Gfxbin.Characters;

public class NoctisData
{
    public static List<BoneHeader> PreloadedBones => new()
    {
        new BoneHeader {Name = "C_Spine3", LodIndex = 262143},
        new BoneHeader {Name = "C_Neck1", LodIndex = 327679},
        new BoneHeader {Name = "C_Head", LodIndex = 393215},
        new BoneHeader {Name = "Facial_A", LodIndex = 458751},
        new BoneHeader {Name = "L_Dlash", LodIndex = 458758},
        new BoneHeader {Name = "R_Dlash", LodIndex = 524294},
        new BoneHeader {Name = "R_Ucheek_B", LodIndex = 589830},
        new BoneHeader {Name = "L_Dcor", LodIndex = 655366},
        new BoneHeader {Name = "R_Dcor", LodIndex = 720902},
        new BoneHeader {Name = "L_Fold_C", LodIndex = 786438},
        new BoneHeader {Name = "R_Fold_C", LodIndex = 851974},
        new BoneHeader {Name = "L_Ucheek_B", LodIndex = 917510},
        new BoneHeader {Name = "R_Ulipout_B", LodIndex = 983046},
        new BoneHeader {Name = "C_Glabella_B", LodIndex = 1048582},
        new BoneHeader {Name = "L_Ulipout_B", LodIndex = 1114118},
        new BoneHeader {Name = "R_Dlid_G", LodIndex = 1179654},
        new BoneHeader {Name = "R_Dlid_F", LodIndex = 1245190},
        new BoneHeader {Name = "L_Dlid_G", LodIndex = 1310726},
        new BoneHeader {Name = "L_Dlid_F", LodIndex = 1376262},
        new BoneHeader {Name = "R_Dlipout_C", LodIndex = 1441798},
        new BoneHeader {Name = "L_Dlipout_A", LodIndex = 1507334},
        new BoneHeader {Name = "R_Nose_D", LodIndex = 1572870},
        new BoneHeader {Name = "L_Nose_A", LodIndex = 1638406},
        new BoneHeader {Name = "C_Nose_A", LodIndex = 1703942},
        new BoneHeader {Name = "C_Nose_B", LodIndex = 1769478},
        new BoneHeader {Name = "C_Chin", LodIndex = 1835014},
        new BoneHeader {Name = "R_Dstk_C", LodIndex = 1900550},
        new BoneHeader {Name = "L_Dstk_C", LodIndex = 1966086},
        new BoneHeader {Name = "R_Dstk_B", LodIndex = 2031622},
        new BoneHeader {Name = "L_Dstk_B", LodIndex = 2097158},
        new BoneHeader {Name = "R_Dstk_A", LodIndex = 2162694},
        new BoneHeader {Name = "L_Dstk_A", LodIndex = 2228230},
        new BoneHeader {Name = "C_Dstk", LodIndex = 2293766},
        new BoneHeader {Name = "R_Ustk_C", LodIndex = 2359302},
        new BoneHeader {Name = "L_Ustk_C", LodIndex = 2424838},
        new BoneHeader {Name = "R_Ustk_B", LodIndex = 2490374},
        new BoneHeader {Name = "L_Ustk_B", LodIndex = 2555910},
        new BoneHeader {Name = "R_Ustk_A", LodIndex = 2621446},
        new BoneHeader {Name = "L_Ustk_A", LodIndex = 2686982},
        new BoneHeader {Name = "C_Ustk", LodIndex = 2752518},
        new BoneHeader {Name = "C_Dteeth", LodIndex = 2818054},
        new BoneHeader {Name = "C_Uteeth", LodIndex = 2883590},
        new BoneHeader {Name = "C_Tongroot", LodIndex = 2949126},
        new BoneHeader {Name = "C_Tongtip", LodIndex = 3014662},
        new BoneHeader {Name = "R_Gonion", LodIndex = 3080198},
        new BoneHeader {Name = "L_Gonion", LodIndex = 3145734},
        new BoneHeader {Name = "R_Chin", LodIndex = 3211270},
        new BoneHeader {Name = "L_Chin", LodIndex = 3276806},
        new BoneHeader {Name = "C_Throat_A", LodIndex = 3342342},
        new BoneHeader {Name = "C_Jaw", LodIndex = 3407878},
        new BoneHeader {Name = "R_Dlipout_B", LodIndex = 3473414},
        new BoneHeader {Name = "L_Dlipout_C", LodIndex = 3538950},
        new BoneHeader {Name = "R_Dlipout_A", LodIndex = 3604486},
        new BoneHeader {Name = "L_Dlipout_B", LodIndex = 3670022},
        new BoneHeader {Name = "R_Ulipout_C", LodIndex = 3735558},
        new BoneHeader {Name = "L_Ulipout_C", LodIndex = 3801094},
        new BoneHeader {Name = "R_Ulipout_A", LodIndex = 3866630},
        new BoneHeader {Name = "L_Ulipout_A", LodIndex = 3932166},
        new BoneHeader {Name = "R_Dcheek_A", LodIndex = 3997702},
        new BoneHeader {Name = "L_Dcheek_A", LodIndex = 4063238},
        new BoneHeader {Name = "R_Ucor", LodIndex = 4128774},
        new BoneHeader {Name = "L_Ucor", LodIndex = 4194310},
        new BoneHeader {Name = "R_Dlip_B", LodIndex = 4259846},
        new BoneHeader {Name = "L_Dlip_B", LodIndex = 4325382},
        new BoneHeader {Name = "R_Dlip_A", LodIndex = 4390918},
        new BoneHeader {Name = "L_Dlip_A", LodIndex = 4456454},
        new BoneHeader {Name = "C_Dlip", LodIndex = 4521990},
        new BoneHeader {Name = "R_Ulip_B", LodIndex = 4587526},
        new BoneHeader {Name = "L_Ulip_B", LodIndex = 4653062},
        new BoneHeader {Name = "R_Ulip_A", LodIndex = 4718598},
        new BoneHeader {Name = "L_Ulip_A", LodIndex = 4784134},
        new BoneHeader {Name = "C_Ulip", LodIndex = 4849670},
        new BoneHeader {Name = "R_Laughline_B", LodIndex = 4915206},
        new BoneHeader {Name = "L_Laughline_B", LodIndex = 4980742},
        new BoneHeader {Name = "R_Laughline_A", LodIndex = 5046278},
        new BoneHeader {Name = "L_Laughline_A", LodIndex = 5111814},
        new BoneHeader {Name = "R_Dcheek_B", LodIndex = 5177350},
        new BoneHeader {Name = "L_Dcheek_B", LodIndex = 5242886},
        new BoneHeader {Name = "R_Ucheek_C", LodIndex = 5308422},
        new BoneHeader {Name = "L_Ucheek_C", LodIndex = 5373958},
        new BoneHeader {Name = "R_Ucheek_D", LodIndex = 5439494},
        new BoneHeader {Name = "L_Ucheek_D", LodIndex = 5505030},
        new BoneHeader {Name = "R_Ucheek_A", LodIndex = 5570566},
        new BoneHeader {Name = "L_Ucheek_A", LodIndex = 5636102},
        new BoneHeader {Name = "R_Nose_C", LodIndex = 5701638},
        new BoneHeader {Name = "L_Nose_D", LodIndex = 5767174},
        new BoneHeader {Name = "R_Nose_B", LodIndex = 5832710},
        new BoneHeader {Name = "L_Nose_C", LodIndex = 5898246},
        new BoneHeader {Name = "R_Nose_A", LodIndex = 5963782},
        new BoneHeader {Name = "L_Nose_B", LodIndex = 6029318},
        new BoneHeader {Name = "R_Dlid_E", LodIndex = 6094854},
        new BoneHeader {Name = "L_Dlid_E", LodIndex = 6160390},
        new BoneHeader {Name = "R_Dlid_D", LodIndex = 6225926},
        new BoneHeader {Name = "L_Dlid_D", LodIndex = 6291462},
        new BoneHeader {Name = "R_Dlid_C", LodIndex = 6356998},
        new BoneHeader {Name = "L_Dlid_C", LodIndex = 6422534},
        new BoneHeader {Name = "R_Dlid_B", LodIndex = 6488070},
        new BoneHeader {Name = "L_Dlid_B", LodIndex = 6553606},
        new BoneHeader {Name = "R_Dlid_A", LodIndex = 6619142},
        new BoneHeader {Name = "L_Dlid_A", LodIndex = 6684678},
        new BoneHeader {Name = "R_Ulid_E", LodIndex = 6750214},
        new BoneHeader {Name = "L_Ulid_E", LodIndex = 6815750},
        new BoneHeader {Name = "R_Ulid_D", LodIndex = 6881286},
        new BoneHeader {Name = "L_Ulid_D", LodIndex = 6946822},
        new BoneHeader {Name = "R_Ulid_C", LodIndex = 7012358},
        new BoneHeader {Name = "L_Ulid_C", LodIndex = 7077894},
        new BoneHeader {Name = "R_Ulid_B", LodIndex = 7143430},
        new BoneHeader {Name = "L_Ulid_B", LodIndex = 7208966},
        new BoneHeader {Name = "R_Ulid_A", LodIndex = 7274502},
        new BoneHeader {Name = "L_Ulid_A", LodIndex = 7340038},
        new BoneHeader {Name = "R_Fold_B", LodIndex = 7405574},
        new BoneHeader {Name = "L_Fold_B", LodIndex = 7471110},
        new BoneHeader {Name = "R_Fold_A", LodIndex = 7536646},
        new BoneHeader {Name = "L_Fold_A", LodIndex = 7602182},
        new BoneHeader {Name = "R_Eye", LodIndex = 7667718},
        new BoneHeader {Name = "L_Eye", LodIndex = 7733254},
        new BoneHeader {Name = "L_Brow_D", LodIndex = 7798790},
        new BoneHeader {Name = "R_Brow_D", LodIndex = 7864326},
        new BoneHeader {Name = "L_Brow_C", LodIndex = 7929862},
        new BoneHeader {Name = "R_Brow_C", LodIndex = 7995398},
        new BoneHeader {Name = "L_Brow_B", LodIndex = 8060934},
        new BoneHeader {Name = "R_Brow_B", LodIndex = 8126470},
        new BoneHeader {Name = "R_Brow_A", LodIndex = 8192006},
        new BoneHeader {Name = "L_Brow_A", LodIndex = 8257542},
        new BoneHeader {Name = "R_Forehead", LodIndex = 8323078},
        new BoneHeader {Name = "L_Forehead", LodIndex = 8388614},
        new BoneHeader {Name = "C_Glabella_A", LodIndex = 8454150},
        new BoneHeader {Name = "C_HairA", LodIndex = 8716287},
        new BoneHeader {Name = "C_HairI1", LodIndex = 8847359},
        new BoneHeader {Name = "C_HairI2", LodIndex = 8912895},
        new BoneHeader {Name = "C_HairE1", LodIndex = 9043967},
        new BoneHeader {Name = "C_HairE2", LodIndex = 9109503},
        new BoneHeader {Name = "C_HairH1", LodIndex = 9240575},
        new BoneHeader {Name = "C_HairH2", LodIndex = 9306111},
        new BoneHeader {Name = "C_HairC1", LodIndex = 9437183},
        new BoneHeader {Name = "C_HairC2", LodIndex = 9502719},
        new BoneHeader {Name = "C_HairJ1", LodIndex = 9633791},
        new BoneHeader {Name = "C_HairJ2", LodIndex = 9699327},
        new BoneHeader {Name = "C_HairK1", LodIndex = 9830399},
        new BoneHeader {Name = "C_HairK2", LodIndex = 9895935},
        new BoneHeader {Name = "C_HairD", LodIndex = 10027007},
        new BoneHeader {Name = "C_HairF1", LodIndex = 10158079},
        new BoneHeader {Name = "C_HairF2", LodIndex = 10223615},
        new BoneHeader {Name = "L_HairB1", LodIndex = 10354687},
        new BoneHeader {Name = "L_HairB2", LodIndex = 10420223},
        new BoneHeader {Name = "L_HairC1", LodIndex = 10551295},
        new BoneHeader {Name = "L_HairC2", LodIndex = 10616831},
        new BoneHeader {Name = "L_HairA", LodIndex = 10747903},
        new BoneHeader {Name = "R_HairB1", LodIndex = 10878975},
        new BoneHeader {Name = "R_HairB2", LodIndex = 10944511},
        new BoneHeader {Name = "R_HairA1", LodIndex = 11075583},
        new BoneHeader {Name = "R_HairA2", LodIndex = 11141119},
        new BoneHeader {Name = "C_HairL", LodIndex = 11272191},
        new BoneHeader {Name = "C_HairM1", LodIndex = 11403263},
        new BoneHeader {Name = "C_HairM2", LodIndex = 11468799},
        new BoneHeader {Name = "L_HairD1", LodIndex = 11599871},
        new BoneHeader {Name = "L_HairD2", LodIndex = 11665407},
        new BoneHeader {Name = "C_HairN", LodIndex = 11796479},
        new BoneHeader {Name = "L_HairE1", LodIndex = 11927551},
        new BoneHeader {Name = "L_HairE2", LodIndex = 11993087},
        new BoneHeader {Name = "L_HairF1", LodIndex = 12124159},
        new BoneHeader {Name = "L_HairF2", LodIndex = 12189695},
        new BoneHeader {Name = "L_HairH", LodIndex = 12320767},
        new BoneHeader {Name = "L_HairJ", LodIndex = 12451839},
        new BoneHeader {Name = "R_HairI", LodIndex = 12582911},
        new BoneHeader {Name = "R_HairJ", LodIndex = 12713983},
        new BoneHeader {Name = "R_HairE1", LodIndex = 12845055},
        new BoneHeader {Name = "R_HairE2", LodIndex = 12910591},
        new BoneHeader {Name = "R_HairF1", LodIndex = 13041663},
        new BoneHeader {Name = "R_HairF2", LodIndex = 13107199},
        new BoneHeader {Name = "C_HairP", LodIndex = 13238271},
        new BoneHeader {Name = "L_HairO", LodIndex = 13369343},
        new BoneHeader {Name = "R_HairO", LodIndex = 13500415},
        new BoneHeader {Name = "L_HairN", LodIndex = 13631487},
        new BoneHeader {Name = "R_HairN", LodIndex = 13762559},
        new BoneHeader {Name = "C_HairO", LodIndex = 13893631},
        new BoneHeader {Name = "R_HairG", LodIndex = 14024703},
        new BoneHeader {Name = "L_HairG", LodIndex = 14155775},
        new BoneHeader {Name = "L_HairI", LodIndex = 14286847},
        new BoneHeader {Name = "R_HairH", LodIndex = 14417919},
        new BoneHeader {Name = "R_HairC1", LodIndex = 14548991},
        new BoneHeader {Name = "R_HairC2", LodIndex = 14614527},
        new BoneHeader {Name = "R_HairD", LodIndex = 14745599},
        new BoneHeader {Name = "C_HairB1", LodIndex = 14876671},
        new BoneHeader {Name = "C_HairB2", LodIndex = 14942207},
        new BoneHeader {Name = "C_HairG1", LodIndex = 15073279},
        new BoneHeader {Name = "C_HairG2", LodIndex = 15138815},
        new BoneHeader {Name = "C_HairS1", LodIndex = 15269887},
        new BoneHeader {Name = "C_HairS2", LodIndex = 15335423},
        new BoneHeader {Name = "L_HairP1", LodIndex = 15466495},
        new BoneHeader {Name = "L_HairP2", LodIndex = 15532031},
        new BoneHeader {Name = "L_HairQ", LodIndex = 15663103},
        new BoneHeader {Name = "C_HairQ1", LodIndex = 15859711},
        new BoneHeader {Name = "R_HairL1", LodIndex = 16056319},
        new BoneHeader {Name = "L_HairM1", LodIndex = 16252927},
        new BoneHeader {Name = "L_HairL1", LodIndex = 16515071},
        new BoneHeader {Name = "L_HairL2", LodIndex = 16580607},
        new BoneHeader {Name = "C_HairR1", LodIndex = 16842751},
        new BoneHeader {Name = "C_HairR2", LodIndex = 16908287},
        new BoneHeader {Name = "R_HairM1", LodIndex = 17170431},
        new BoneHeader {Name = "R_HairM2", LodIndex = 17235967},
        new BoneHeader {Name = "L_HairK", LodIndex = 17432575},
        new BoneHeader {Name = "R_HairK", LodIndex = 17629183},
        new BoneHeader {Name = "C_Throat_B", LodIndex = 17825791},
        new BoneHeader {Name = "C_NeckSub", LodIndex = 17891327},
        new BoneHeader {Name = "C_Neck1W", LodIndex = 18022399},
        new BoneHeader {Name = "L_Shoulder", LodIndex = 18153471},
        new BoneHeader {Name = "R_Shoulder", LodIndex = 21495807},
        new BoneHeader {Name = "R_Middle1", LodIndex = 22413311}
    };
}