using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class RGBMazeScript : MonoBehaviour {

    public KMAudio Audio;
    public List<KMSelectable> gridbuttons;
    public Renderer[] gridleds;
    public Renderer[] framework;
    public KMColorblindMode colblind;
    public Renderer[] segdisplay;
    public TextMesh[] segcol;
    public Renderer[] orientleds;
    public TextMesh[] orientledcol;
    public Renderer[] meter;
    public TextMesh[] ledcol;
    public TextMesh mazecol;
    public Material[] colours;

    private string[][] mazes = new string[10][]
    {
        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X     X     X   X",
                         "X XXXXXXXXX X XXX",
                         "X X   X   X X X X",
                         "XXXXX XXX XXX X X",
                         "X   X   X   X X X",
                         "X XXXXXXXXXXXXX X",
                         "X X     X     X X",
                         "X XXX XXXXX XXX X",
                         "X X X X   X X X X",
                         "XXX XXX XXXXX XXX",
                         "X   X   X X     X",
                         "XXX XXXXX XXXXXXX",
                         "X X X   X     X X",
                         "X XXXXX XXXXXXX X",
                         "X     X   X     X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X       X   X   X",
                         "XXXXXXXXXXX XXX X",
                         "X   X     X   X X",
                         "X XXXXXXX XXXXX X",
                         "X X     X X   X X",
                         "X X XXXXXXX XXXXX",
                         "X X X X X   X   X",
                         "XXXXX X XXXXX XXX",
                         "X X   X   X   X X",
                         "X XXX X XXXXXXX X",
                         "X   X X X     X X",
                         "X XXXXXXX XXXXX X",
                         "X X   X X X X   X",
                         "XXX XXX XXX XXXXX",
                         "X   X     X     X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X X     X   X   X",
                         "X XXX XXXXX XXX X",
                         "X   X X   X   X X",
                         "X XXXXXXX XXXXX X",
                         "X X     X   X X X",
                         "XXXXXXX XXXXX XXX",
                         "X     X X   X   X",
                         "XXX XXXXXXX XXX X",
                         "X X X     X X X X",
                         "X XXXXXXX X X XXX",
                         "X X   X X X X   X",
                         "X X XXX XXXXXXX X",
                         "X X X   X   X X X",
                         "X X X XXX XXX XXX",
                         "X X X X   X     X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X   X     X     X",
                         "XXX XXX XXX XXXXX",
                         "X X   X X X X   X",
                         "X XXXXXXX XXX XXX",
                         "X X   X   X   X X",
                         "X XXX XXX XXXXX X",
                         "X   X   X X   X X",
                         "XXXXXXXXXXX XXX X",
                         "X   X     X X   X",
                         "XXX XXXXX X XXXXX",
                         "X X   X X X X   X",
                         "X XXXXX XXXXX XXX",
                         "X   X X   X X   X",
                         "X XXX XXX X XXXXX",
                         "X X     X X     X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X X     X     X X",
                         "X X XXXXXXXXX X X",
                         "X X X       X X X",
                         "X XXXXXXXXXXXXX X",
                         "X   X   X X X   X",
                         "XXXXX XXX X XXXXX",
                         "X X   X   X   X X",
                         "X XXXXX XXX XXX X",
                         "X   X X X X X   X",
                         "XXX X XXX XXX XXX",
                         "X X X   X   X X X",
                         "X XXX XXXXX XXX X",
                         "X   X X X X X   X",
                         "X XXXXX X XXXXX X",
                         "X X     X     X X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X X     X     X X",
                         "X XXXXX XXXXX X X",
                         "X     X X   X X X",
                         "XXXXXXXXX X XXX X",
                         "X X     X X X   X",
                         "X X XXXXXXXXXXXXX",
                         "X X X X     X X X",
                         "X XXX XXX XXX X X",
                         "X X     X X   X X",
                         "X XXXXXXXXX XXX X",
                         "X X X X   X X   X",
                         "XXX X X XXXXXXXXX",
                         "X X   X X     X X",
                         "X XXXXX X XXXXX X",
                         "X     X X X     X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X   X     X X   X",
                         "X XXXXX XXX X X X",
                         "X   X X X X X X X",
                         "XXXXX XXX X XXXXX",
                         "X X     X X   X X",
                         "X XXXXXXX XXXXX X",
                         "X   X   X   X   X",
                         "X XXXXX XXXXXXX X",
                         "X X   X   X   X X",
                         "XXX XXXXXXXXX XXX",
                         "X   X X X   X   X",
                         "XXXXX X XXX XXXXX",
                         "X X X X   X X   X",
                         "X X X XXX X XXX X",
                         "X   X   X X X   X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X   X X X X   X X",
                         "XXX X X X X XXX X",
                         "X X X X   X X   X",
                         "X X X XXXXX X XXX",
                         "X X X   X X X X X",
                         "X XXXXXXX XXXXX X",
                         "X X   X     X   X",
                         "X X XXXXXXXXXXX X",
                         "X X X X     X X X",
                         "XXX X XXXXX X XXX",
                         "X X X   X X X   X",
                         "X XXXXX X XXXXX X",
                         "X     X X X   X X",
                         "XXXXXXXXX XXX XXX",
                         "X       X   X   X",
                         "XXXXXXXXXXXXXXXXX"},

        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X   X X     X   X",
                         "X XXX XXX XXXXX X",
                         "X   X   X X X   X",
                         "XXXXXXX XXX XXXXX",
                         "X     X X X   X X",
                         "X XXXXXXX XXX X X",
                         "X X X X     X X X",
                         "XXX X XXXXXXXXX X",
                         "X   X   X     X X",
                         "X XXXXX X XXXXX X",
                         "X X   X X X   X X",
                         "XXXXX XXXXXXX XXX",
                         "X   X   X X X   X",
                         "X XXXXXXX X XXXXX",
                         "X   X     X     X",
                         "XXXXXXXXXXXXXXXXX"},


        new string[17] { "XXXXXXXXXXXXXXXXX",
                         "X     X X X     X",
                         "XXXXX X X X XXXXX",
                         "X   X X X X X   X",
                         "X X XXX X XXXXX X",
                         "X X X X X   X X X",
                         "XXXXX X XXXXX X X",
                         "X X X X X X   X X",
                         "X X X XXX X XXXXX",
                         "X   X   X X X   X",
                         "XXXXXXXXX XXXXX X",
                         "X X X   X   X X X",
                         "X X XXX XXXXX X X",
                         "X   X X   X X X X",
                         "XXXXX XXXXX X XXX",
                         "X     X     X   X",
                         "XXXXXXXXXXXXXXXXX"},

    };
    private string[] gridmaze = new string[17];
    private int[][] keylocations = new int[3][] { new int[2] { -5, -5 }, new int[2] { -5, -5 }, new int[2] { -5, -5 } };
    private int[][] mazenumber = new int[3][] { new int[2], new int[2], new int[2] };
    private bool[][] segon = new bool[3][] { new bool[7], new bool[7], new bool[7] };
    private int[] pos = new int[2];
    private bool[] collect = new bool[3];
    private int currentcol;
    private bool firstmove = true;
    private bool exit;
    private int[] exitlocation = new int[3];
    private bool colb;

    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Awake()
    {
        moduleID = moduleIDCounter++;
        foreach(Renderer m in meter)
        {
            m.material = colours[0];
        }
        foreach(Renderer s in segdisplay)
        {
            s.material = colours[0];
        }
        foreach(Renderer l in orientleds)
        {
            l.material = colours[0];
        }
        foreach(KMSelectable button in gridbuttons)
        {
            int b = gridbuttons.IndexOf(button);
            gridleds[b].material = colours[0];
            button.OnInteract += delegate () { Press(b); return false; };
        }
    }

    void Start ()
    {
        colb = colblind.ColorblindModeActive;
        pos[0] = Random.Range(0, 8);
        pos[1] = Random.Range(0, 8);
        exitlocation[0] = Random.Range(0, 3);
        exitlocation[1] = Random.Range(0, 8);
        exitlocation[2] = Random.Range(0, 8);
        Debug.LogFormat("[RGB Maze #{2}]The starting location is {0}{1}", "ABCDEFGH"[pos[1]], "12345678"[pos[0]], moduleID);
        for (int i = 0; i < 3; i++)
        {
            mazenumber[i][0] = -1;
            keylocations[i][0] = Random.Range(0, 8);
            keylocations[i][1] = Random.Range(0, 8);
            while(Mathf.Abs(keylocations[i][0] - pos[0]) + Mathf.Abs(keylocations[i][1] - pos[1]) < 4 || ((Mathf.Abs(keylocations[1][0] - keylocations[0][0]) + Mathf.Abs(keylocations[1][1] - keylocations[0][1]) < 4) && i == 1) || ((Mathf.Abs(keylocations[2][0] - keylocations[0][0]) + Mathf.Abs(keylocations[2][1] - keylocations[0][1]) < 4 || Mathf.Abs(keylocations[2][0] - keylocations[1][0]) + Mathf.Abs(keylocations[2][1] - keylocations[1][1]) < 4) && i == 2))
            {
                keylocations[i][0] = Random.Range(0, 8);
                keylocations[i][1] = Random.Range(0, 8);
            }
            gridleds[8 * keylocations[i][0] + keylocations[i][1]].material = colours[i + 1];
        }
        for (int i = 0; i < 3; i++)
        {
            List<string>[] grid = new List<string>[17] { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { } };
            mazenumber[i][0] = Random.Range(0, 10);
            mazenumber[i][1] = Random.Range(0, 4);
            switch (i)
            {
                case 0:
                for (int j = 0; j < 17; j++)
                {
                    for (int k = 0; k < 17; k++)
                    {
                        switch (mazenumber[0][1])
                        {
                            case 1:
                                if (mazes[mazenumber[0][0]][j][16 - k] == 'X')
                                {
                                    grid[j].Add("R");
                                }
                                else
                                {
                                    grid[j].Add("K");
                                }
                                break;
                            case 2:
                                if (mazes[mazenumber[0][0]][16 - j][16 - k] == 'X')
                                {
                                    grid[j].Add("R");
                                }
                                else
                                {
                                    grid[j].Add("K");
                                }
                                break;
                            case 3:
                                if (mazes[mazenumber[0][0]][16 - j][k] == 'X')
                                {
                                    grid[j].Add("R");
                                }
                                else
                                {
                                    grid[j].Add("K");
                                }
                                break;
                            default:
                                if (mazes[mazenumber[0][0]][j][k] == 'X')
                                {
                                    grid[j].Add("R");
                                }
                                else
                                {
                                    grid[j].Add("K");
                                }
                                break;
                        }
                    }
                }
                   break;
                case 1:
                    while (mazenumber[1][0] == mazenumber[0][0])
                        mazenumber[1][0] = Random.Range(0, 10);
                    for (int j = 0; j < 17; j++)
                    {
                        for (int k = 0; k < 17; k++)
                        {
                            switch (mazenumber[1][1])
                            {
                                case 1:
                                    if (mazes[mazenumber[1][0]][j][16 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 2:
                                    if (mazes[mazenumber[1][0]][16 - j][16 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 3:
                                    if (mazes[mazenumber[1][0]][16 - j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                default:
                                    if (mazes[mazenumber[1][0]][j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'R')
                                            grid[j].Add("Y");
                                        else
                                            grid[j].Add("G");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    while (mazenumber[2][0] == mazenumber[0][0] || mazenumber[2][0] == mazenumber[1][0])
                        mazenumber[2][0] = Random.Range(0, 10);
                    for (int j = 0; j < 17; j++)
                    {
                        for (int k = 0; k < 17; k++)
                        {
                            switch (mazenumber[2][1])
                            {
                                case 1:
                                    if (mazes[mazenumber[2][0]][j][16 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if(gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 2:
                                    if (mazes[mazenumber[2][0]][16 - j][16 - k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                case 3:
                                    if (mazes[mazenumber[2][0]][16 - j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                                default:
                                    if (mazes[mazenumber[2][0]][j][k] == 'X')
                                    {
                                        if (gridmaze[j][k] == 'Y')
                                            grid[j].Add("W");
                                        else if (gridmaze[j][k] == 'R')
                                            grid[j].Add("M");
                                        else if (gridmaze[j][k] == 'G')
                                            grid[j].Add("C");
                                        else
                                            grid[j].Add("B");
                                    }
                                    else
                                    {
                                        grid[j].Add(gridmaze[j][k].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
            Debug.LogFormat("[RGB Maze #{2}]The {3} key is located at {0}{1}", "ABCDEFGH"[keylocations[i][1]], "12345678"[keylocations[i][0]], moduleID, new string[3] {"red", "green", "blue" }[i]);
            if(colb == true)
            {
                ledcol[i].text = "ABCDEFGH"[keylocations[i][1]].ToString() + "12345678"[keylocations[i][0]].ToString();
            }
            Debug.LogFormat("[RGB Maze #{2}]The {3} maze is maze {0}{1}", mazenumber[i][0], new string[4] {string.Empty, " flipped horizontally", " flipped horizontally and vertically", " flipped vertically" }[mazenumber[i][1]], moduleID, new string[3] {"red", "green", "blue" }[i]);
            for (int j = 0; j < 17; j++)
            {
                gridmaze[j] = string.Join(string.Empty, grid[j].ToArray());
            }
            switch (mazenumber[i][0])
            {
                case 0:
                    segon[i] = new bool[7] { true, true, true, false, true, true, true};
                    break;
                case 1:
                    segon[i] = new bool[7] { false, false, true, false, false, true, false };
                    break;
                case 2:
                    segon[i] = new bool[7] { true, false, true, true, true, false, true };
                    break;
                case 3:
                    segon[i] = new bool[7] { true, false, true, true, false, true, true };
                    break;
                case 4:
                    segon[i] = new bool[7] { false, true, true, true, false, true, false };
                    break;
                case 5:
                    segon[i] = new bool[7] { true, true, false, true, false, true, true };
                    break;
                case 6:
                    segon[i] = new bool[7] { true, true, false, true, true, true, true };
                    break;
                case 7:
                    segon[i] = new bool[7] { true, false, true, false, false, true, false };
                    break;
                case 9:
                    segon[i] = new bool[7] { true, true, true, true, false, true, true };
                    break;
                default:
                    segon[i] = new bool[7] { true, true, true, true, true, true, true };
                    break;
            }
        }
        string gridmaez = string.Empty;
        for(int i = 0; i < 17; i++)
        {
            gridmaez +=  "\n[RGB Maze #" + moduleID + "]" + gridmaze[i]; 
        }
        Debug.LogFormat("[RGB Maze #{0}]The grid:{1}",moduleID, gridmaez);
        for (int i = 0; i < 7; i++)
        {
            int switchseg = 0;
            for(int j = 0; j < 3; j++)
            {
                if (segon[j][i] == true)
                    switchseg += (int)Mathf.Pow(2, 2 - j);
            }
            switch (switchseg)
            {
                case 1:
                    segdisplay[i].material = colours[3];
                    break;
                case 2:
                    segdisplay[i].material = colours[2];
                    break;
                case 3:
                    segdisplay[i].material = colours[5];
                    break;
                case 4:
                    segdisplay[i].material = colours[1];
                    break;
                case 5:
                    segdisplay[i].material = colours[6];
                    break;
                case 6:
                    segdisplay[i].material = colours[7];
                    break;
                case 7:
                    segdisplay[i].material = colours[8];
                    break;
            }
            if(colb == true)
               segcol[i].text = "KBGCRMYW"[switchseg].ToString();
        }
        for(int i = 0; i < 4; i++)
        {
            int ledkey = 0;
            for (int j = 0; j < 3; j++)
            {
                if (mazenumber[j][1] == i)
                    ledkey += (int)Mathf.Pow(2, 2 - j);
            }
            switch (ledkey)
            {
                case 1:
                    orientleds[i].material = colours[3];
                    break;
                case 2:
                    orientleds[i].material = colours[2];
                    break;
                case 3:
                    orientleds[i].material = colours[5];
                    break;
                case 4:
                    orientleds[i].material = colours[1];
                    break;
                case 5:
                    orientleds[i].material = colours[6];
                    break;
                case 6:
                    orientleds[i].material = colours[7];
                    break;
                case 7:
                    orientleds[i].material = colours[8];
                    break;
            }
            if(colb == true)
                orientledcol[i].text = "KBGCRMYW"[ledkey].ToString();
        }
	}

    private void Press(int b)
    {
        if (firstmove == true)
        {
            firstmove = false;
            Audio.PlaySoundAtTransform("Switch", transform);
            if (colb == true)
            {
                mazecol.text = "R";
            }
            gridleds[8 * pos[0] + pos[1]].material = colours[8];
            previousButton = 8 * pos[0] + pos[1];
            if (pos[0] > 0)
                gridleds[8 * (pos[0] - 1) + pos[1]].material = colours[4];
            if (pos[1] > 0)
                gridleds[8 * pos[0] + pos[1] - 1].material = colours[4];
            if (pos[0] < 7)
                gridleds[8 * (pos[0] + 1) + pos[1]].material = colours[4];
            if (pos[1] < 7)
                gridleds[8 * pos[0] + pos[1] + 1].material = colours[4];
            foreach (Renderer frame in framework)
            {
                frame.material = colours[1];
            }
            for (int i = 0; i < 3; i++)
            {
                gridleds[8 * keylocations[i][0] + keylocations[i][1]].material = colours[0];
                ledcol[i].text = string.Empty;
            }
        }
        else if(moduleSolved == false)
        {
            if (pos[0] > 0)
                gridleds[8 * (pos[0] - 1) + pos[1]].material = colours[0];
            if (pos[1] > 0)
                gridleds[8 * pos[0] + pos[1] - 1].material = colours[0];
            if (pos[0] < 7)
                gridleds[8 * (pos[0] + 1) + pos[1]].material = colours[0];
            if (pos[1] < 7)
                gridleds[8 * pos[0] + pos[1] + 1].material = colours[0];
            if (b == 8 * (pos[0] - 1) + pos[1])
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'R' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'G' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'B' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'C' || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'M')) || gridmaze[2 * pos[0]][2 * pos[1] + 1] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[RGB Maze #{0}]Error: Hit {1} wall north of {2}{3}", moduleID, gridmaze[2 * pos[0]][2 * pos[1] + 1], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 8 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if(exit == true && currentcol != exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 8 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[0]--;
                        }
                    }
                }
            }
            else if (b == 8 * pos[0] + pos[1] - 1)
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'R' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'G' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'B' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'C' || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'M')) || gridmaze[2 * pos[0] + 1][2 * pos[1]] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[RGB Maze #{0}]Error: Hit {1} wall west of {2}{3}", moduleID, gridmaze[2 * pos[0] + 1][2 * pos[1]], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 8 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 8 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[1]--;
                        }
                    }
                }
            }
            else if (b == 8 * (pos[0] + 1) + pos[1])
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'R' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'G' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'B' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'C' || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'M')) || gridmaze[2 * pos[0] + 2][2 * pos[1] + 1] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[RGB Maze #{0}]Error: Hit {1} wall south of {2}{3}", moduleID, gridmaze[2 * pos[0] + 2][2 * pos[1] + 1], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 8 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 8 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[0]++;
                        }
                    }
                }
            }
            else if (b == 8 * pos[0] + pos[1] + 1)
            {
                if ((currentcol == 0 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'R' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 1] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'M')) || (currentcol == 1 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'G' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'Y' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'C')) || (currentcol == 2 && (gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'B' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'C' || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'M')) || gridmaze[2 * pos[0] + 1][2 * pos[1] + 2] == 'W')
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    Debug.LogFormat("[RGB Maze #{0}]Error: Hit {1} wall east of {2}{3}", moduleID, gridmaze[2 * pos[0] + 1][2 * pos[1] + 2], "ABCDEFGH"[pos[1]], "12345678"[pos[0]]);
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < 3)
                        {
                            if (currentcol != i && b == 8 * keylocations[i][0] + keylocations[i][1] && collect[i] == false)
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to collect {1} key from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                            else if (exit == true && currentcol != exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                Debug.LogFormat("[RGB Maze #{0}]Error: Attempted to exit through {1} exit from {2} maze", moduleID, "RGB"[i], "RGB"[currentcol]);
                                break;
                            }
                        }
                        else
                        {
                            Audio.PlaySoundAtTransform("Move", transform);
                            for (int j = 0; j < 3; j++)
                            {
                                if (exit == false)
                                {
                                    if (currentcol == j && b == 8 * keylocations[j][0] + keylocations[j][1] && collect[j] == false)
                                    {
                                        collect[j] = true;
                                        Audio.PlaySoundAtTransform("InputCorrect", transform);
                                        Debug.LogFormat("[RGB Maze #{0}]{1} key collected", moduleID, "RGB"[j]);
                                        meter[j].material = colours[j + 1];
                                    }
                                }
                                else if (currentcol == exitlocation[0] && b == 8 * exitlocation[1] + exitlocation[2])
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    break;
                                }
                            }
                            pos[1]++;
                        }
                    }
                }
            }
            else if (b == 8 * pos[0] + pos[1])
            {
                currentcol++;
                currentcol %= 3;
                Audio.PlaySoundAtTransform("Switch", transform);
                if (colb == true)
                {
                    mazecol.text = "RGB"[currentcol].ToString();
                }
                foreach (Renderer frame in framework)
                {
                    frame.material = colours[currentcol + 1];
                }
            }
            if (collect[0] == true && collect[1] == true && collect[2] == true && exit == false)
            {
                exit = true;
                Debug.LogFormat("[RGB Maze #{0}]All keys collected: the exit lies at {1}{2} in the {3} maze", moduleID, "ABCDEFGH"[exitlocation[2]], "12345678"[exitlocation[1]], "RGB"[exitlocation[0]]);      
                switch (exitlocation[1])
                {
                    case 0:
                        segon[1] = new bool[7] { false, false, true, false, false, true, false };
                        break;
                    case 1:
                        segon[1] = new bool[7] { true, false, true, true, true, false, true };
                        break;
                    case 2:
                        segon[1] = new bool[7] { true, false, true, true, false, true, true };
                        break;
                    case 3:
                        segon[1] = new bool[7] { false, true, true, true, false, true, false };
                        break;
                    case 4:
                        segon[1] = new bool[7] { true, true, false, true, false, true, true };
                        break;
                    case 5:
                        segon[1] = new bool[7] { true, true, false, true, true, true, true };
                        break;
                    case 6:
                        segon[1] = new bool[7] { true, false, true, false, false, true, false };
                        break;
                    default:
                        segon[1] = new bool[7] { true, true, true, true, true, true, true };
                        break;
                }                           
                switch (exitlocation[2])
                {
                    case 0:
                        segon[2] = new bool[7] { true, true, true, true, true, true, false };
                        break;
                    case 1:
                        segon[2] = new bool[7] { false, true, false, true, true, true, true };
                        break;
                    case 2:
                        segon[2] = new bool[7] { true, true, false, false, true, false, true };
                        break;
                    case 3:
                        segon[2] = new bool[7] { false, false, true, true, true, true, true };
                        break;
                    case 4:
                        segon[2] = new bool[7] { true, true, false, true, true, false, true };
                        break;
                    case 5:
                        segon[2] = new bool[7] { true, true, false, true, true, false, false };
                        break;
                    case 6:
                        segon[2] = new bool[7] { true, true, false, false, true, true, true };
                        break;
                    default:
                        segon[2] = new bool[7] { false, true, true, true, true, true, false };
                        break;
                }                                                                                             
                switch (Random.Range(0, 10))
                {
                    case 0:
                        segon[0] = new bool[7] { true, false, false, true, false, false, true };
                        break;
                    case 1:
                        segon[0] = new bool[7] { false, true, true, true, true, true, true };
                        break;
                    case 2:
                        segon[0] = new bool[7] { false, false, false, true, true, true, true };
                        break;
                    case 3:
                        segon[0] = new bool[7] { false, true, true, false, true, true, false };
                        break;
                    case 4:
                        segon[0] = new bool[7] { true, false, false, true, false, false, true };
                        break;
                    case 5:
                        segon[0] = new bool[7] { true, false, true, false, false, true, true };
                        break;
                    case 6:
                        segon[0] = new bool[7] { true, false, false, true, true, true, false };
                        break;
                    case 7:
                        segon[0] = new bool[7] { true, true, true, true, false, false, true };
                        break;
                    case 8:
                        segon[0] = new bool[7] { true, false, true, false, true, false, true };
                        break;
                    case 9:
                        segon[0] = new bool[7] { true, true, true, false, true, true, false };
                        break;
                }
                for (int i = 0; i < 7; i++)
                {
                    int switchseg = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (segon[(j + 3 - exitlocation[0]) % 3][i] == true)
                            switchseg += (int)Mathf.Pow(2, 2 - j);
                    }
                    switch (switchseg)
                    {
                        case 1:
                            segdisplay[i].material = colours[3];
                            break;
                        case 2:
                            segdisplay[i].material = colours[2];
                            break;
                        case 3:
                            segdisplay[i].material = colours[5];
                            break;
                        case 4:
                            segdisplay[i].material = colours[1];
                            break;
                        case 5:
                            segdisplay[i].material = colours[6];
                            break;
                        case 6:
                            segdisplay[i].material = colours[7];
                            break;
                        case 7:
                            segdisplay[i].material = colours[8];
                            break;
                        default:
                            segdisplay[i].material = colours[0];
                            break;
                    }
                    if (colb == true)
                        segcol[i].text = "KBGCRMYW"[switchseg].ToString();                                             
                }
            }
            if (moduleSolved == false)
            {
                gridleds[8 * pos[0] + pos[1]].material = colours[8];
                previousButton = 8 * pos[0] + pos[1];
                if (pos[0] > 0)
                    gridleds[8 * (pos[0] - 1) + pos[1]].material = colours[4];
                if (pos[1] > 0)
                    gridleds[8 * pos[0] + pos[1] - 1].material = colours[4];
                if (pos[0] < 7)
                    gridleds[8 * (pos[0] + 1) + pos[1]].material = colours[4];
                if (pos[1] < 7)
                    gridleds[8 * pos[0] + pos[1] + 1].material = colours[4];
            }
            else
            {
                Audio.PlaySoundAtTransform("Exit", transform);
                mazecol.text = string.Empty;
                gridleds[8 * pos[0] + pos[1]].material = colours[0];
                if (pos[0] > 0)
                    gridleds[8 * (pos[0] - 1) + pos[1]].material = colours[0];
                if (pos[1] > 0)
                    gridleds[8 * pos[0] + pos[1] - 1].material = colours[0];
                if (pos[0] < 7)
                    gridleds[8 * (pos[0] + 1) + pos[1]].material = colours[0];
                if (pos[1] < 7)
                    gridleds[8 * pos[0] + pos[1] + 1].material = colours[0];
                foreach (Renderer thing in framework)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in meter)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in orientleds)
                {
                    thing.material = colours[0];
                }
                foreach (Renderer thing in segdisplay)
                {
                    thing.material = colours[0];
                }
                foreach (TextMesh thing in ledcol)
                {
                    thing.text = string.Empty;
                }
                foreach (TextMesh thing in orientledcol)
                {
                    thing.text = string.Empty;
                }
                foreach (TextMesh thing in segcol)
                {
                    thing.text = string.Empty;
                }
            }
        }
    }

    //twitch plays
    private int previousButton;

    private bool commandIsValid(string s)
    {
        char[] valids = { 'u', 'd', 'l', 'r', 'R', 'G', 'B' };
        s = s.Replace(" ", "");
        for(int i = 0; i < s.Length; i++)
        {
            if (!valids.Contains(s[i]))
            {
                return false;
            }
        }
        return true;
    }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} start [Starts the module] | !{0} u/d/l/r [Moves in the specified direction] | !{0} R/G/B [Switches to the specified maze] | !{0} reset [Resets the module ENTIRELY] | Move and switch commands may be chained, for example '!{0} rdGuuRr'";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*start\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            if(firstmove == true)
            {
                gridbuttons[0].OnInteract();
            }
            else
            {
                yield return "sendtochaterror The module has already been started!";
            }
            yield break;
        }
        if (Regex.IsMatch(command, @"^\s*reset\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            Debug.LogFormat("[RGB Maze #{0}] Reset of module triggered! [TP]", moduleID);
            for (int i = 0; i < gridleds.Length; i++)
            {
                gridleds[i].material = colours[0];
            }
            for (int i = 0; i < orientleds.Length; i++)
            {
                orientleds[i].material = colours[0];
            }
            for (int i = 0; i < framework.Length; i++)
            {
                framework[i].material = colours[8];
            }
            firstmove = true;
            Start();
            yield break;
        }
        if (commandIsValid(command) && firstmove == false)
        {
            yield return null;
            string temp = "";
            temp = command.Replace(" ", "");
            for(int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals('u'))
                {
                    if((previousButton-8) < 0)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton - 8].OnInteract();
                    }
                }
                else if (temp[i].Equals('d'))
                {
                    if ((previousButton + 8) > 63)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton + 8].OnInteract();
                    }
                }
                else if (temp[i].Equals('l'))
                {
                    if (((previousButton % 8) - 1) < 0)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton - 1].OnInteract();
                    }
                }
                else if (temp[i].Equals('r'))
                {
                    if (((previousButton % 8) + 1) > 7)
                    {
                        yield break;
                    }
                    else
                    {
                        gridbuttons[previousButton + 1].OnInteract();
                    }
                }
                else if (temp[i].Equals('R'))
                {
                    while(currentcol != 0)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (temp[i].Equals('G'))
                {
                    while (currentcol != 1)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else if (temp[i].Equals('B'))
                {
                    while (currentcol != 2)
                    {
                        gridbuttons[previousButton].OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
