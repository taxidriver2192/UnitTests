## Opgave 1 C# og Unit tests

### **Opgave Beskrivelse**

> - [x] Lav et projekt af typen “Class Library (.NET core)”.
> - [x] Lav en klasse *Cykel* med properties (bemærk de forskellige constraints):
>
> - Id, et tal
> - Farve, tekst-streng, min 1 tegn langt
> - Pris, tal, pris > 0
> - Gear, 3 <= gear<= 32
>
> - [x] Det må ikke være muligt at konstruere objekter, som bryder ovenstående constraints.
> - [x] Hvis ovennævnte constraints ikke overholdes skal der kastes *passende* exceptions. Dette gælder også for constructors.
> - [x] Tilføj en unit test til dit projekt. Test din Cykel klasse.
> - [x] Din test test skal have et godt “Code Coverage”

### **Opgave Besvarelse**

[Link til cykel klassen](https://github.com/taxidriver2192/UnitTests)

[Link til unit testen](https://github.com/taxidriver2192/UnitTestsTests)

Først startede jeg med at lave et nyt projekt i visual studio 2019, `File -> New -> Projekt -> Class Library (.NET core`

Derefter lavet jeg et projekt navn til opgaven og trykket på `Create`

#### Cykel klasse

Oprettet en cykel klasse ud efter hvad opgave beskrivelsen beskrev jeg skulle bruge. 

Mine parmeter var således i min cykel klase.

```c#
Id = id;
Farve = farve;
Pris = pris;
Gear = gear;
```

Derfor endte hele min cykel class med at se således ud.

```c#
using System;
namespace UnitTests
{
    public class cykel
    {
        private int _id;
        private string _farve;
        private int _pris;
        private int _gear;

        public cykel(int id, string farve, int pris, int gear)
        {
            Id = id;
            Farve = farve;
            Pris = pris;
            Gear = gear;
        }

        public cykel()
        {
        }
        
        public int Id
        {
            get => _id;
            set => _id = value;
     	}
     	 public string Farve
        {
            get => _farve;
            set => _farve = value;
        }
        public int Pris
        {
            get => _pris;
            set => _pris = value;
        }
        public int Gear
        {
            get => _gear;
            set => _gear = value;
        }
   	}
}
```

##### Cykel klassens Interface

Nu skulle jeg så overfolde opgave beskrivelsen, derfor rettet jeg alle cykel klassens Interface.

###### Farve

`Farve, tekst-streng, min 1 tegn langt`

Farve Interface kode.

```c#
public string Farve
{
	get => _farve;
	set
	{
		if (value.Length < 1) throw new ArgumentOutOfRangeException();
		_farve = value;
	}
}
```

###### Pris

`Pris, tal, pris > 0`

Gear Interface kode.

```c#
 public int Pris
 {
     get => _pris;
     set
     {
         if (value > 0)
         {
             _pris = value;
         }
         else
         {
             throw new ArgumentOutOfRangeException("Skal være over 0");
         }
     }
 }
```

###### Gear

`Gear, 3 <= gear<= 32`

Pris Interface kode.

```c#
public int Gear
{
    get => _gear;
    set
    {
        if (value < 3 || value > 32) throw new ArgumentOutOfRangeException("Talet skal være mellem 3 og 32");
        _gear = value;
    }
}
```

##### Færdig cykel klasse

[Linket til GitHub repositorie Cykel klassen](https://github.com/taxidriver2192/UnitTests)

Nedenstående kan du se den færdig kode til cykel klassen.

```c#
using System;
namespace UnitTests
{
    public class cykel
    {
        private int _id;
        private string _farve;
        private int _pris;
        private int _gear;

        public cykel(int id, string farve, int pris, int gear)
        {
            Id = id;
            Farve = farve;
            Pris = pris;
            Gear = gear;
        }

        public cykel()
        {
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set
            {
                if (value.Length < 1) throw new ArgumentOutOfRangeException();
                _farve = value;
            }
        }

        public int Pris
        {
            get => _pris;
            set
            {
                if (value > 0)
                {
                    _pris = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Skal være over 0");
                }
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value < 3 || value > 32) throw new ArgumentOutOfRangeException("Talet skal være mellem 3 og 32");
                _gear = value;
            }
        }
    }
}
```



#### Unit Tests 

[Linket til GitHub repositorie Cykel klasse Unit test](https://github.com/taxidriver2192/UnitTestsTests)

Derefter oprettet jeg min unit test af programmet, sådan at jeg testet grænse værdighederne.

Nedenstående kan du se den færdig kode til cykel Unit test.

```c#
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Tests
{
    [TestClass()]
    public class cykelTests
    {
        private cykel cykel;

        [TestInitialize]
        public void Init()
        {
            cykel = new cykel(1,"gul",22,6);
        }

        [TestMethod()]
        public void cykelFarveTest()
        {
            Assert.AreEqual("gul",cykel.Farve);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cykel.Farve = "");
        }

        [TestMethod()]
        public void cykelPrisTest()
        {
            Assert.AreEqual(22, cykel.Pris);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cykel.Pris = 0);
        }
        [TestMethod()]
        public void cykelGearTest()
        {
            Assert.AreEqual(6, cykel.Gear);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cykel.Gear = 2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cykel.Gear = 33);

        }
    }
}
```

##### Kørte testen

Her kan du se et billede at testen kørt hvor jeg tester alle grænse værdighederne.

![](https://github.com/taxidriver2192/UnitTestsTests/blob/main/unit%20test%20green.PNG?raw=true)
