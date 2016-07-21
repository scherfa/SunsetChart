using System.Collections.Generic;
using System.Linq;

namespace SunsetChart
{
    
   public class CityPositions
    {
        private readonly List<CityPosition> m_positions = new List<CityPosition>();

        public List<CityPosition> Positions => m_positions;

       public CityPositions()
        {
            m_positions.Add(new CityPosition { Country = "GER", Caption = "Berlin", Latitude = 52.5234051, Longitude = 13.4113999 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Hamburg", Latitude = 53.5534074, Longitude = 9.9921962 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "München",  Latitude = 48.1391265, Longitude = 11.5801863 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Köln",  Latitude = 50.9406645, Longitude = 6.9599115 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Frankfurt am Main",  Latitude = 50.1115118, Longitude = 8.6805059 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Stuttgart",  Latitude = 48.7771056, Longitude = 9.1807688 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Trier",  Latitude = 49.753735, Longitude = 6.646247 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Dortmund",  Latitude = 51.5120542, Longitude = 7.4635729 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Essen", Latitude = 51.4580686, Longitude = 7.0147614 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Düsseldorf",  Latitude = 51.2249429, Longitude = 6.7756524 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bremen",  Latitude = 53.074981, Longitude = 8.807081 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Hannover",  Latitude = 52.3720683, Longitude = 9.7356861 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Leipzig",  Latitude = 51.3396802, Longitude = 12.3713006 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Dresden",  Latitude = 51.0509576, Longitude = 13.733658 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Nürnberg",  Latitude = 49.45052, Longitude = 11.08048 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Duisburg",  Latitude = 51.4327884, Longitude = 6.7680565 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bochum",  Latitude = 51.482901, Longitude = 7.21181 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Wuppertal",  Latitude = 51.255871, Longitude = 7.149985 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bielefeld",  Latitude = 52.022993, Longitude = 8.533117 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bonn",  Latitude = 50.7327045, Longitude = 7.0963113 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Mannheim",  Latitude = 49.4846773, Longitude = 8.476724 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Karlsruhe",  Latitude = 49.0080848, Longitude = 8.4037563 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Wiesbaden",  Latitude = 50.0840697, Longitude = 8.2383811 });
                                                        
            m_positions.Add(new CityPosition { Country="GER", Caption = "Münster (Westfalen)",  Latitude = 51.966667, Longitude = 7.633333 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Gelsenkirchen",  Latitude = 51.5115316, Longitude = 7.0930303 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Augsburg",  Latitude = 48.3654574, Longitude = 10.8947684 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Mönchengladbach",  Latitude = 51.191261, Longitude = 6.442066 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Aachen",  Latitude = 50.7765852, Longitude = 6.0836128 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Braunschweig",  Latitude = 52.264141, Longitude = 10.526381 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Chemnitz",  Latitude = 50.832503, Longitude = 12.924694 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Kiel",  Latitude = 54.322684, Longitude = 10.13586 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Krefeld",  Latitude = 51.331702, Longitude = 6.559343 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Halle (Saale)1",  Latitude = 51.5189633, Longitude = 11.9118905 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Magdeburg",  Latitude = 52.130956, Longitude = 11.636701 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Freiburg im Breisgau",  Latitude = 47.9971865, Longitude = 7.8537668 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Oberhausen",  Latitude = 51.469612, Longitude = 6.8658829 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Lübeck",  Latitude = 53.869563, Longitude = 10.687579 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Erfurt",  Latitude = 50.9737346, Longitude = 11.0223989 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Rostock",  Latitude = 54.0901331, Longitude = 12.1329562 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Mainz",  Latitude = 49.9951227, Longitude = 8.2674264 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Kassel",  Latitude = 51.318928, Longitude = 9.49601 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Hagen",  Latitude = 51.362328, Longitude = 7.463116 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Hamm",  Latitude = 51.680386, Longitude = 7.817429 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Saarbrücken",  Latitude = 49.2348506, Longitude = 6.9944016 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Mülheim an der Ruhr",  Latitude = 51.427073, Longitude = 6.886492 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Herne",  Latitude = 51.538523, Longitude = 7.219237 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Ludwigshafen am Rhein",  Latitude = 49.4807019, Longitude = 8.4412294 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Osnabrück",  Latitude = 52.267272, Longitude = 8.053193 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Solingen",  Latitude = 51.172145, Longitude = 7.083391 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Leverkusen",  Latitude = 51.033728, Longitude = 6.987211 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Oldenburg",  Latitude = 53.1367227, Longitude = 8.2165291 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Neuss",  Latitude = 51.1984294, Longitude = 6.69529 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Potsdam",  Latitude = 52.3969627, Longitude = 13.0586008 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Heidelberg",  Latitude = 49.401929, Longitude = 8.6802394 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Paderborn",  Latitude = 51.715254, Longitude = 8.75213 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Darmstadt",  Latitude = 49.8724245, Longitude = 8.6508574 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Würzburg",  Latitude = 49.794256, Longitude = 9.927489 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Regensburg",  Latitude = 49.016491, Longitude = 12.100904 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Ingolstadt",  Latitude = 48.762145, Longitude = 11.425389 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Heilbronn",  Latitude = 49.141598, Longitude = 9.222083 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Göttingen",  Latitude = 51.5326383, Longitude = 9.92816 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Ulm",  Latitude = 48.399623, Longitude = 9.996607 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Recklinghausen",  Latitude = 51.611287, Longitude = 7.197382 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Wolfsburg",  Latitude = 52.4218204, Longitude = 10.7849799 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Pforzheim",  Latitude = 48.8933731, Longitude = 8.7043826 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bottrop",  Latitude = 51.522229, Longitude = 6.924209 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Offenbach am Main",  Latitude = 50.1053208, Longitude = 8.7584717 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bremerhaven",  Latitude = 53.548243, Longitude = 8.582657 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Fürth",  Latitude = 49.4772463, Longitude = 10.9897065 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Remscheid",  Latitude = 51.1793042, Longitude = 7.193936 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Reutlingen",  Latitude = 48.490891, Longitude = 9.205842 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Moers",  Latitude = 51.453042, Longitude = 6.6217202 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Koblenz",  Latitude = 50.356718, Longitude = 7.599485 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Bergisch Gladbach",  Latitude = 50.9917694, Longitude = 7.1364837 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Salzgitter",  Latitude = 52.1522617, Longitude = 10.3310138 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Siegen",  Latitude = 50.873797, Longitude = 8.023407 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Erlangen",  Latitude = 49.599937, Longitude = 11.0063 });
                                           
            m_positions.Add(new CityPosition { Country="GER", Caption = "Hildesheim", Latitude = 52.1509, Longitude = 9.951001 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Cottbus", Latitude = 51.7607843, Longitude = 14.3274812 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Euskirchen", Latitude = 50.660202, Longitude = 6.7912754 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Cottbus", Latitude = 51.7607843, Longitude = 14.3274812 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Jena", Latitude = 50.9269994, Longitude = 11.5870113 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Gera", Latitude = 50.880385, Longitude = 12.081214 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Witten", Latitude = 51.437475, Longitude = 7.337293 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Kaiserslautern", Latitude = 49.4447102, Longitude = 7.7690305 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Wyk auf Föhr", Latitude = 54.691944, Longitude = 8.559444 });
            m_positions.Add(new CityPosition { Country="GER", Caption = "Konstanz", Latitude = 47.661279, Longitude = 9.172061 });
            m_positions.Add(new CityPosition { Country="GER",Caption = "Pulheim", Latitude = 50.9988374, Longitude = 6.7981391});
            m_positions.Add(new CityPosition { Country="GER",Caption = "Flensburg", Latitude = 54.780395, Longitude = 9.435707});
            m_positions.Add(new CityPosition { Country="GER",Caption = "Fehmarn", Latitude = 54.478056, Longitude = 11.12});
            /*
            
            Gütersloh 	51.904903 	8.39279
            Iserlohn 	51.3729333 	7.6992867
            Schwerin 	53.6257542 	11.4168765
            Zwickau 	50.7146939 	12.4968657
            Düren 	50.7998461 	6.486958
            Ratingen 	51.296859 	6.847082
            Esslingen am Neckar 	48.741097 	9.308052
            Dessau-Roßlau2 	0 	0
            Marl 	51.6531811 	7.0978069
            Lünen 	51.618117 	7.524524
            Hanau 	50.135407 	8.915129
          
            Ludwigsburg 	48.901911 	9.193265
            Velbert 	51.3388677 	7.0427113
            Tübingen 	48.522904 	9.052098
            Minden 	52.289987 	8.922157
            Worms 	49.630644 	8.357911
            Wilhelmshaven 	53.517063 	8.119749
            Konstanz 	47.661279 	9.172061
            Villingen-Schwenningen 	48.0553902 	8.460072
            Marburg 	50.814788 	8.769239
            Dorsten 	51.659089 	6.966174
            Neumünster 	54.0741 	9.98458
            Lüdenscheid 	51.215468 	7.63507
            Castrop-Rauxel 	51.559467 	7.323476
            Rheine 	52.2765838 	7.4384809
            Gladbeck 	51.5731274 	6.9883787
            Viersen 	51.255706 	6.398319
            Arnsberg 	51.3952673 	8.0686871
            Delmenhorst 	53.051494 	8.6332609
            Troisdorf 	50.8140803 	7.1542906
            Gießen 	50.584007 	8.678247
            Detmold 	51.935414 	8.873843
            Bocholt 	51.83857 	6.622471
            Bayreuth 	49.941598 	11.571146
            Brandenburg an der Havel 	52.408418 	12.562492
            Lüneburg 	53.2459377 	10.409343
            Norderstedt 	53.6735016 	9.9855895
            Celle 	52.6219201 	10.0785804
            Dinslaken 	51.565124 	6.732924
            Bamberg 	49.894218 	10.885527
            Aschaffenburg 	49.973 	9.148977
            Unna 	51.534471 	7.685883
            Plauen 	50.49501 	12.13836
            Lippstadt 	51.6763815 	8.3466483
            Neubrandenburg 	53.558054 	13.261224
            Aalen 	48.835973 	10.08991
            Neuwied 	50.426671 	7.461901
            Herford 	52.116457 	8.669133
            Weimar 	50.979163 	11.32428
            Kerpen 	50.872602 	6.692641
            Grevenbroich 	51.089651 	6.585602
            Fulda 	50.553861 	9.674339
            Herten 	51.593151 	7.140439
            Dormagen 	51.093055 	6.842117
            Bergheim 	50.955052 	6.639992
            Landshut 	48.538823 	12.151825
            Garbsen 	52.413849 	9.588131
            Frankfurt (Oder) 	52.3471444 	14.5504683
            Kempten (Allgäu) 	47.723937 	10.311047
            Wesel 	51.6608279 	6.6091553
            Schwäbisch Gmünd 	48.802302 	9.802771
            Sindelfingen 	48.7084614 	9.0035555
            Rosenheim 	47.856077 	12.124018
            Rüsselsheim 	49.994874 	8.410858
            Langenfeld (Rheinland) 	51.102447 	6.947116
            Offenburg 	48.467987 	7.942387
            Hameln 	52.104018 	9.357208
            Friedrichshafen 	47.6519684 	9.4784851
            Stolberg (Rheinland) 	50.776107 	6.224172
            Stralsund 	54.3137829 	13.0857932
            Göppingen 	48.703158 	9.653999
            Menden (Sauerland) 	51.4389247 	7.7936429
            Görlitz 	51.153139 	14.975297
            Hattingen 	51.399058 	7.1876
            Hürth 	50.870961 	6.868111
            Hilden 	51.1667206 	6.9312505
            Sankt Augustin 	50.772491 	7.190686
            Eschweiler 	50.817428 	6.271667
         
            Baden-Baden 	48.7598004 	8.2397925
            Ahlen 	51.762481 	7.88604
            Bad Salzuflen 	52.08534 	8.742499
            Meerbusch 	51.261268 	6.677683
            Wolfenbüttel 	52.1623152 	10.5322398
            Greifswald 	54.0972025 	13.3880102
            Schweinfurt 	50.049113 	10.231144
           
            Neustadt an der Weinstraße 	49.35027 	8.137919
            Nordhorn 	52.4358821 	7.0742302
            Waiblingen 	48.8320254 	9.314109
            Gummersbach 	51.02835 	7.5653958
            Neu-Ulm 	48.3841086 	10.0097395
            Willich 	51.26496 	6.551767
            Wetzlar 	50.550978 	8.503477
            Bad Homburg vor der Höhe 	50.227153 	8.615926
            Emden 	53.364336 	7.201198
            Langenhagen 	52.447312 	9.739651
            Bergkamen 	51.6129973 	7.6307506
            Cuxhaven 	53.861701 	8.694068
            Lingen (Ems) 	52.52306 	7.323279
            Ibbenbüren 	52.276254 	7.7185617
            Erftstadt 	50.803063 	6.767463
            Passau 	48.573512 	13.463918
            Speyer 	49.3172844 	8.4310066
            */

            // Other Cities
            m_positions.Add(new CityPosition { Country = "BRA", Caption = "Rio de Janeiro", TimeZone = "E. South America Standard Time", Latitude = -22.908333, Longitude = -43.196389 });
            m_positions.Add(new CityPosition { Country = "IDN", Caption = "Pontianak ", TimeZone = "SE Asia Standard Time", Latitude =  -0.016667, Longitude = 109.333333 });
            m_positions.Add(new CityPosition { Country = "FJD", Caption = "Fiji ", TimeZone = "Fiji Standard Time", Latitude = -18.0, Longitude = 179.0 });
        }

       public CityPosition GetCityPosition(object selectedValue)
       {
           return m_positions.FirstOrDefault(cityPosition => cityPosition.Caption == (string) selectedValue);
       }
    }
}
