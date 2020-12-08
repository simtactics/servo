# Servo

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/simtactics/servo/HEAD?urlpath=lab) [![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0) [![License: ODbL](https://img.shields.io/badge/License-ODbL-brightgreen.svg)](https://opendatacommons.org/licenses/odbl/)

Servo is a experimental re-imagining of SimAntics using ML.NET with Jupyter Notebooks. While [current re-implementations](https://github.com/riperiperi/FreeSO) exist, maintaining that code independently of the project has proven to be tedious and exhausting because it has to much ties to the game engine it was build around of. Servo is meant to be a fresh and clean design with the only relation to Sims coming from public [design documents](https://users.cs.northwestern.edu/~forbus/c95-gd/lectures/The_Sims_Under_the_Hood_files/v3_document.htm).

## Requirements

## Prerequisites

- [.NET](https://dotnet.microsoft.com/download) 5+ or Core 3.1
- [.NET Interactive](https://github.com/dotnet/interactive/blob/main/README.md)
    - [VSCode Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode) (does not require Jupyter)
    - [nteract](https://nteract.io/) (requires Jupyter)

## Design

### Motive Engine

The Motive Engine is based on opposing weights. An object signals it's presence if the Sim's need is low. The need is the motive and that drives a Sims' decision. All games in the franchise are based on this dynamic at it's core. For example, if hunger is low then the fridge's presence is high and vice versa. A Sim's mood is the sum of the current state of their motives. They will only choose the fridge if it increases it's overall mood. The ML portion comes in deciding which has the priority.

A Sim's motives decrease in increments and independently of each other during game play. They are randomized for this experiment.

### Decision Engine

The actual decision making is handled by ML.NET's recommendation algorithms based on Action, Need, and Threshold where Threshold is the "Rating", Need is the "User" and Action is the "Item". For example:

| Action       | Need   | Min | Max |
| ------------ | ------ | --- | --- |
| Refrigerator | Hunger | 10  | 30  |
| Toy          | Fun    | 60  | 70  |

The decision engine keeps an eye on the motives and the queue. The threshold is how the low the motive has to be in order for a Sim to use an object. Just like in The Sims, this can be tuned afterwards. However, In Under the Hood of The Sims says that the final decision is based on whether the fridge increases the current mood as a whole, not the hunger motive.

Current dataset design is NOT FINAL.

## License

I license the source code for this project under the Apache 2.0, see [LICENSE](LICENSE), and data sets under the Open Database License, see [DATA-LICENSE](DATA-LICENSE).
