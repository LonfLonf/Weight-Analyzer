using System;
using People;

namespace CharacterLogic
{
    class Character
    {
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public Person person { get; set; }
        string[] asciiArt = new string[]
{
    @"
                            .       .
                           / `.   .' \
                   .---.  <    > <    >  .---.
                   |    \  \ - ~ ~ - /  /    |
                    ~-..-~             ~-..-~
                \~~~\.'                    `./~~~/
                 \__/                        \__/
                  /                  .-    .  \
           _._ _.-    .-~ ~-.       /       }   \/~~~/
       _.-'q  }~     /       }     {        ;    \__/
      {'__,  /      (       /      {       /      `. ,~~|   .     .
       `''''='~~-.__(      /_      |      /- _      `..-'   \\   //
                   / \   =/  ~~--~~{    ./|    ~-.     `-..__\\_//_.-'
                  {   \  +\         \  =\ (        ~ - . _ _ _..---~
                  |  | {   }         \   \_\
                 '---.o___,'       .o___,'     ""Stegosaurus""",
    @"
                                                        .--.__
                                                      .~ (@)  ~~~---_
                                                     {     `-_~,,,,,,)
                                                     {    (_  ',
                                                      ~    . = _',
                                                       ~-   '.  =-'
                                                         ~     :
      .                                             _,.-~     ('');
      '.                                         .-~        \  \ ;
        ':-_                                _.--~            \  \;      _-=,.
          ~-:-.__                       _.-~                 {  '---- _'-=,.
             ~-._~--._             __.-~                     ~---------=,.`
                 ~~-._~~-----~~~~~~       .+++~~~~~~~~-__   /
                      ~-.,____           {   -     +   }  _/
                              ~~-.______{_    _ -=\ / /_.~
                                   :      ~--~    // /         ..-
                                   :   / /      // /         ((
                                   :  / /      {   `-------,. ))
                                   :   /        ''=--------. }o
                      .=._________,'  )                     ))
                      )  _________ -''                     ~~
                     / /  _ _
                    (_.-.'O'-'.        ""Deinonychus""",
    @"
                                  ___......__             _
                              _.-'           ~-_       _.=a~~-_
      --=====-.-.-_----------~   .--.       _   -.__.-~ ( ___==>
                    '''--...__  (    \ \\\ { )       _.-~
                              =_ ~_  \\-~~~//~~~~-=-~
                               |-=-~_ \\   \\
                               |_/   =. )   ~}
                               |}      ||
                              //       ||
                            _//        {{
       ""Hypsilophodon""   '='~'          \\_
                                         ~~'",
    @"
                                             .--.
                                            {(~~)}
                           __..._         _.''''a`,._
                       _.-'      '~-._.-~~     (  .__}
                    _-~                       _.`--j|
                 _-~     _         /~\    _.-~     &|
              _-~     ,-~ ~-.      \\ ) .~
            .'       {       )      \\|'
          .'         {       /  _.-' |:
        .'            \     /.-'     \\
      .'        __.-~.=\   /          `}
      ;      _.-~   / ./ |  }
      {    _.'     / /   | /
      {    =      {=+__  | :
      :   :_      `-- = \,_`-,.
       `.   '=,_
          '-.___'_::='         ""Corythosaur""",
    @"
                       _..--+~/@-~--.
                   _-=~      (  .   '
                _-~     _.--=.\ \''''
              _~      _-       \ \_\
             =      _=          '--'
            '      =                             .
           :      :       ____                   '=_. ___
      ___  |      ;                            ____ '~--.~.
           ;      ;                               _____  } |
        ___=       \ ___ __     __..-...__           ___/__/__
           :        =_     _.-~~          ~~--.__
      _____ \         ~-+-~                   ___~=_______
           ~@#~~ == ...______ __ ___ _--~~--_                  ""Pleisiosaur"""
};

        public Character(Person person)
        {
            this.person = person;
            setlevel();
            this.Experience = 0;
            this.Health = 100;
        }

        public void LevelUp()
        {
            Level++;
            Health = 100;
        }

        public void drawDummy()
        {
            Console.WriteLine(asciiArt[Level]);
        }

        public void setlevel()
        {
            float imc = person.IMC;
            if (imc < 18.5)
            {
                Level = 1;
            }
            else if (imc >= 18.5 && imc < 24.9)
            {
                Level = 2;
            }
            else if (imc >= 24.9 && imc < 29.9)
            {
                Level = 3;
            }
            else if (imc >= 29.9)
            {
                Level = 4;
            }
            else if (imc >= 40)
            {
                Level = 5;
            }
        }
    }
}