using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

    // w = white
    // o = orange
    // c = cyan
    // g = green
    // r = red
    // b = blue
    // p = purple
    // y = yellow
    //
    // d = double hit
    // u = unbreakable
    public static string[] levels = {
            "uuuuuuuuuuuuuuuuuu" +
            "wwwwwwwwwwwwwwwwww" +
            "oooooooooooooooooo" +
            "cccccccccccccccccc" +
            "gggggggggggggggggg" +
            "rrrrrrrrrrrrrrrrrr" +
            "bbbbbbbbbbbbbbbbbb" +
            "pppppppppppppppppp" +
            "yyyyyyyyyyyyyyyyyy" +
            "wwwwwwwwwwwwwwwwww" +
            "dddddddddddddddddd" +
            "dddddddddddddddddd" +
            "wwwwwwwwwwwwwwwwww" +
            "wwwwwwwwwwwwwwwwww" ,
            
            ////level 1
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"    u       w     " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " +
            //"                  " ,

            //level 1
            "                  " +
            "                  " +
            "                  " +
            "  wwwwwwwwwwwwww  " +
            "  wwwwwwwwwwwwww  " +
            "  wwwwwwwwwwwwww  " +
            "  wwwwwwwwwwwwww  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,


            //level 2
            "                  " +
            "wocg              " +
            "wocgrb            " +
            "wocgrbpy          " +
            "wocgrbpywo        " +
            "wocgrbpywocg      " +
            "wocgrbpywocgrb    " +
            "wocgrbpywocgrbpy  " +
            "uuuuuuuuuuuuuuuuu " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,

			//level 3
			"                  " +
			"                  " +
			" wocgr pywo grbpy " +
			" ocgrb ywoc rbpyw " +
			" cgrbp wocg bpywo " +
			" grbpy ocgr pywoc " +
			" rbpyw cgrb ywocg " +
			" bpywo grbp wocgr " +
			" pywoc rbpy ocgrb " +
			"                  " +
			"                  " +
			"                  " +
			"                  " +
			"                  " ,

            //level 4
            "                  " +
            "    yy      yy    " +
            "      y    y      " +
            "    dddddddddd    " +
            "   dddddddddddd   " +
            "  ddddrddddrdddd  " +
            "  dddddddddddddd  " +
            "  d dddddddddd d  " +
            "  d d        d d  " +
            "     ddd  ddd     " +
            "                  " +
			"                  " +
            "                  " +
            "                  " ,

            //level 5
            "                  " +
            "                  " +
            "b r g c yy c g r b" +
            "b r g c yy c g r b" +
			"b ruuuuuuuuuuuur b" +
            "b r g c yy c g r b" +
            "b r g c yy c g r b" +
            "b r g c yy c g r b" +
            "b r g c yy c g r b" +
            "u u u u uu u u u u" +
            "b r g c yy c g r b" +
            "                  " +
            "                  " +
            "                  " ,

            //level 6
            "                  " +
            "                  " +
            " dddddddddddddd u " +
            " wwwwwwwwwwwwww u " +
            " wwwwwwwwwwwwww u " +
            " wwwwwwwwwwwwww u " +
            " wwwwwwwwwwwwww u " +
            " wwwwwwwwwwwwww u " +
            "                u " +
            "uuuuuuuuuuuuuuuuu " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,

			//level 7
			"                  " +
			"                  " +
			"    u  u  u  u    " +
			" uu            uu " +
			" u  u  uwwu  u  u " +
			"     uu bb uu     " +
			"        yy        " +
			" u  u  uddu  u  u " +
			"        yy        " +
			"     uu bb uu     " +
			" u  u  uwwu  u  u " +
			" uu            uu " +
			"    u  u  u  u    " +
			"                  " ,

			//level 8
			"                  " +
			" uccu        uccu " +
			" uccu        uccu " +
			" uuuu        uuuu " +
			"                  " +
			"     pddddddy     " +
			"     puuuuuuy     " +
			"     pccccccy     " +
			"     pggggggy     " +
			"     prrrrrry     " +
			"     pbbbbbby     " +
			"                  " +
			"                  " +
			"                  " ,

			//level 9
			"      yyyyyy      " +
			"     yyyyyyyy     " +
			"    yyyyyyyyyy    " +
			"   yyyyyyyyyyyy   " +
			"   yyrryyyyrryy   " +
			"   yyrryyyyrryy   " +
			"   yyyyyyyyyyyy   " +
			"   yyyyyyyyyyyy   " +
			"   yyryyyyyyryy   " +
			"    yyryyyyryy    " +
			"     yyrrrryy     " +
			"      yyyyyy      " +
			"                  " +
			"                  " ,

			//level 10
			"                  " +
			"  dddddddddddddd  " +
			"  d            d  " +
			"  d dddddddddd d  " +
			"  d d        d d  " +
			"  d d  dddd  d d  " +
			"  d d        d d  " +
			"  d dddddddddd d  " +
			"  d            d  " +
			"  dddddddddddddd  " +
			"                  " +
			"                  " +
			"                  " +
			"                  " ,


            //level 11
			"                  " +
            "uuuuuuuuuuuuuuuuuu" +
            "  u   u       u  w" +
            "      u       u   " +
            "      u   u   u   " +
            "  uy  ug  u   u   " +
            "  u   u   u  bu   " +
            "  u  pu   u   u   " +
            "  u   u  ru   u   " +
            "  uc      u       " +
            "  u       u       " +
            "  uuuuuuuuuuuuuuuu" +
            "u                 " +
            "                  " ,

            //level 12
            "         d        " +
            "        ddd       " +
            "        d d       " +
            "        u         " +
            "        u         " +
            "   u  u u u  u    " +
            "   gggwwwwwbbb    " +
            "   gggwwwwwbbb    " +
            "   gggwwwwwbbb    " +
            "    ggwwwwwbb     " +
            "    gggwwwbbb     " +
            "     gggdbbb      " +
            "        d         " +
            "                  " ,

            //level 13
            "                  " +
            "                  " +
            "                  " +
            "    bb     rrrr   " +
            "   bbb    rr  rr  " +
            "   bbb        rr  " +
            "    bb      rrr   " +
            "    bb      rrr   " +
            "    bb        rr  " +
            "    bb    rr  rr  " +
            "  bbbbbb   rrrr   " +
            "                  " +
            "                  " +
            "                  " ,

            //level 14
            "                  " +
            "bbbbbbbbbbbbbbbbbb" +
            "u                u" +
            "bbbbbbbbbbbbbbbbbb" +
            "                  " +
            "dddddddddddddddddd" +
            "u                u" +
            "dddddddddddddddddd" +
            "                  " +
            "rrrrrrrrrrrrrrrrrr" +
            "u                u" +
            "rrrrrrrrrrrrrrrrrr" +
            "                  " +
            "                  " ,

            //level 15
            "                  " +
            "                  " +
            "  dddddddddddddd  " +
            "  rrwwggyyggwwrr  " +
            "  rrwwggyyggwwrr  " +
            "  uudduudduudduu  " +
            "  uudduudduudduu  " +
            "  rrwwggyyggwwrr  " +
            "  rrwwggyyggwwrr  " +
            "  dddddddddddddd  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,


            //level 16
            "                  " +
            "wwwwwwwwwwwwwwwwww" +
            "gggggggggggggggggg" +
            "rrrrrrrrrrrrrrrrrr" +
            "uuuuuuuddddduuuuuu" +
            "upppppu     ubbbbu" +
            "upppppu     ubbbbu" +
            "u                u" +
            "u                u" +
            "u                u" +
            "u     ugggggu    u" +
            "u     ugggggu    u" +
            "uddddduuuuuuuddddu" +
            "                  " ,
    };
}
