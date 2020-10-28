# Servo

Servo is a experimental re-implementation of SimAntics using ML.NET based on [Under the hood of The Sims](https://users.cs.northwestern.edu/~forbus/c95-gd/lectures/The_Sims_Under_the_Hood_files/v3_document.htm). I have wanted to write my own version of SimAntics for a while but the process of rewriting the engine from scratch pr even maintaining an existing re-implementation, such as FreeSO's, has proven to be tedious. Current machine learning technologies, such as ML.NET, can streamline the process.

That being said, Servo is not intended to be used to rewrite The Sims itself. The models are intended for building new games based on it's design.

## Motive Engine

SimAntics is based on opposing weights. An object signals it's presence if the Sims' need is low. The need is the motive and that drives a Sims' decision. All games in the franchise are based on this dynamic at it's core. For example, if hunger is low then the fridge's presence is high and vice versa.

The sum of all the Sims' needs is it's mood. A Sim will only choose the fridge if it increases it's overall mood. The individual needs is the classification while the mood is the prediction.

## License

I license this project under the GNU GPL v3 - see the [LICENSE](LICENSE) file for details.
