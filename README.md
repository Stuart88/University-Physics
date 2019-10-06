# University-Physics

University Physics is a C# library for performing physics calculations of all kinds. It's mainly for my own enjoyment, 
but will probably be useful for things like games, simulators, education and simple research tasks.

At first I intend to work through the classic [University Physics](https://www.amazon.com/University-Physics-Modern-15th/dp/0135159555) 
text book, turning the equations and examples contained in the book  into usable classes and methods for generating quick 
answers to problems.

Please check the [documentation](https://github.com/Stuart88/University-Physics/wiki) for details and implementations.

The below example shows how to find the centre of mass of any set of particles in 3D space.

```c#
          
           Particle[] myParticles = new Particle[]
           {
                new Particle(position: new Vector(0,0,0), mass: 1),
                new Particle(position: new Vector(0,1,0), mass: 1),
                new Particle(position: new Vector(1,0,0), mass: 1),
                new Particle(position: new Vector(1,1,0), mass: 1),
           };
           
           Vector centreOfMass = myParticles.CentreOfMass();
           
           // centreOfMass.ToString() ====> X: 0.5, Y: 0.5, Z: 0
```

All classes and methods take relevant SI units as parameters. 

For example: 

`mass: 1` =  1kg

`position: Vector(1,0,0)` = 1m in the x-direction on Cartesian axes


After I've worked through University Physics, I'll shift over to more advanced topics that I covered later during my own degree studies.

## Main Topics
- [Vectors](https://github.com/Stuart88/University-Physics/wiki/Vectors)
- [Mechanics](https://github.com/Stuart88/University-Physics/wiki/Mechanics)
- Electromagnetism
- Waves
- Thermodynamics
- Quantum Mechanics
- Relativity
- Fluid Dynamics
 
## Advanced Topics

- Geophysical Fluid Dynamics
- Error-Correcting Codes
- Advanced Mechanics
- Advanced Quantum Mechanics
