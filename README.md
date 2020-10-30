# Servo

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0) [![License: ODbL](https://img.shields.io/badge/License-ODbL-brightgreen.svg)](https://opendatacommons.org/licenses/odbl/)

Servo is a experimental re-implementation of SimAntics using ML.NET based on [Under the Hood of The Sims](https://users.cs.northwestern.edu/~forbus/c95-gd/lectures/The_Sims_Under_the_Hood_files/v3_document.htm). I have wanted to write my own version of SimAntics for a while but the process of rewriting the engine from scratch or even maintaining an existing re-implementation, such as FreeSO's, has proven to be tedious. Current machine learning technologies, such as ML.NET, can streamline the process. That being said, Servo is not intended to be used to rewrite The Sims itself. The models are intended for building new games based on it's design.

## Design

### Motive Engine

The Motive Engine is based on opposing weights. An object signals it's presence if the Sim's need is low. The need is the motive and that drives a Sims' decision. All games in the franchise are based on this dynamic at it's core. For example, if hunger is low then the fridge's presence is high and vice versa. A Sim's mood is the sum of the current state of their motives. They will only choose the fridge if it increases it's overall mood. The ML portion comes in deciding which has the priority.

A Sim's motives decrease in increments and independently of each other during game play. They are randomized for this experiment.

### Decision Engine

The actual decision making is handled by ML.NET's recommendation algorithms based on Action, Need, and Threshold where Threshold is the "Rating", Need is the "User" and Action is the "Item". For example:

| Action       | Need   | Threshold |
| ------------ | ------ | --------- |
| Refrigerator | Hunger | 30        |
| Refrigerator | Hunger | 28        |
| Refrigerator | Hunger | 24        |
| Refrigerator | Hunger | 21        |
| Refrigerator | Hunger | 20        |

The decision engine keeps an eye on the motives and the queue. However, In Under the Hood of The Sims says that the final decision is based on whether the fridge increases the current mood as a whole, not the hunger motive.

Current dataset design is NOT FINAL.

## License

I license the source code for this project under the GNU GPL v3, see [LICENSE](LICENSE), and data sets under the Open Database License, see [DATA-LICENSE](DATA-LICENSE).
