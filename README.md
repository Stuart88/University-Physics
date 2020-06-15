# University-Physics

### Click here for docs: [documentation](https://github.com/Stuart88/University-Physics/wiki)

University Physics is a C# library for performing physics calculations of all kinds. The project is in its early stages, 
but once ready it will probably be useful for things like games, simulators, education and simple research tasks.

Most of the work will be based on the classic [University Physics](https://www.amazon.com/University-Physics-Modern-15th/dp/0135159555) 
text book, turning the equations and examples contained in the book into usable classes and methods for generating quick 
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


After most content from the University Physics textbook has been covered, more advanced physics topics will be introduced. 

## Main Topics
- Maths
- Mechanics
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

# Contributors

All contributions to University Physics must have working unit tests. 

A new unit test class can be created if the current classes are not suitable.

There are no specific code styling rules for this project, but I will probably go over any contributions and make them look a bit more like "code I would write myself", just so the style of the project remains roughly the same throughout.

I also perioducally perform a big 'code cleanup' operation with ReSharper to get classes and other things arranged uniformly, so if you notice any drastic rearrangements of your work, that might be why.
