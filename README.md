# AR-Knick-Knack
A simple AR cube representation of Grand Teton National Park made with Unity and Vuforia Engine.


### Instructions
To run the application, download the repo into the folder of a Universal 3D Unity Project. You
will have to find and add the Vuforia engine 11.4.4 package. It has been removed from this repo
due to it's large file size.

#### Time of Day
To view differences in the cube state at different times of day open TimeTracker.cs and change
the private variable timeOffset. The tent light will be active from 8 pm to 4 am and the ambient
sound will change to night mode between the hours of 8 pm and 6 am. 
