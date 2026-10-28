# ExtractionThingy

## Illumination
Implementaton: Used shader graph in order to implement  
Diffuse, Ambient, & Specular were the same as shown in class  
Added the ability to toggle each property individually using the keyboard  
Added the Diffuse Wrap Shader  
<img width="852" height="207" alt="image" src="https://github.com/user-attachments/assets/81021323-4fa3-493e-ba4d-84f73ef49473" />  
This creates softer lighting by creating a smoother transition between light and shadow the adjustable values also helps me fine tune it  


## Color grading
implementation: Used shader graph and script to change it  
<img width="1187" height="466" alt="image" src="https://github.com/user-attachments/assets/3ffdf9af-2371-4fb0-bf18-ae79538a6471" />  
## Add how you got LUT here

Used the shader graph shown in the lecture slides as it wasn't covered in class, and experimented with look up tables, and tuned down the contribution of the shader graph to achieve a more natural feel.  
Created a script to swap between each look up table in order to change the look of the game

**Cool LUT**
<img width="256" height="16" alt="CoolLUT" src="https://github.com/user-attachments/assets/cc0b595b-4898-42c2-8196-edc52840f626" />  
**Warm LUT**
<img width="256" height="16" alt="WarmLUT" src="https://github.com/user-attachments/assets/709fc71d-6362-43e6-b286-650571a4c6aa" />  
**Custom LUT**
<img width="256" height="16" alt="CustomLUT" src="https://github.com/user-attachments/assets/df014c90-1a52-4110-b21d-eaa99823f0ec" />  

Used the default LUT table given in class to then put in photo shop and create a filter layer to mess with. After messing with and getting how we wanted it to look just exported it as png to implement into unity

## Shaders
**Creature shader**  
<img width="1150" height="432" alt="image" src="https://github.com/user-attachments/assets/56734e7e-b38e-4a43-ac65-da5b1710a4bb" />  
Simple Fresnel shader that outputs to emission so that there is a variable, when a creature gets hit they will flash a certain color based on the element's attack
**Portal Shader**  
<img width="905" height="465" alt="image" src="https://github.com/user-attachments/assets/6b888df4-db08-463e-b42e-5102c6b2408c" />
Shader that gets the UV and uses the twirl function in shader graph to create a twisting motion for a portal also changed it so that the portal is slightly transparent.  

**Water shader**  

<img width="324" height="174" alt="image" src="https://github.com/user-attachments/assets/d52bc1ba-c3bc-4eed-9f13-eef80d5f03d5" />  
Simple bump shader used in class with a scroll speed to be able to make it flowing. Texture found online  

**Sand shader**

<img width="134" height="51" alt="image" src="https://github.com/user-attachments/assets/b04d2924-8fc7-4d69-9c2c-32575a4885fa" />  
Simple bump shader used in class with tiling that actually was able to be affected so the sand looked better. Texture found online  

## Reflection
Throughout the development of Hunting Grounds, we had no real set roles. This was both a blessing and a curse, where whenever one person would start working on something 
they would have to notify the other person, so as to not step on each other's toes. This allowed us to get an understanding on how each part of the project worked. One of the most difficult 
parts of development was time management. Over the past few months, a lot of our time was spent on other projects, and assignments, leaving little time each week for Hunting Grounds. 
When attempting to create the bump shader in the shader graph it didn't work properly and we were unhappy with the outcome. We switched over to using shaderlab. One of the issues was 
trying to figure out color grading, since color grading was such a new topic, and it was just skimmed over in class, we struggled to obtain a deeper understanding of it. It took us a while 
but eventually we figured it out. Since our proposal was just a framework, we didn’t need to cut out any particular part of the proposal. Overall, this part of the development process has helped 
us figure out the scope of the final project for this assignment.

## Unlisted video
https://youtu.be/kNI-LwwLT5k 
