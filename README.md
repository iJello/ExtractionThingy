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

## Shaders
**Creature shader**  
<img width="1150" height="432" alt="image" src="https://github.com/user-attachments/assets/56734e7e-b38e-4a43-ac65-da5b1710a4bb" />  
Simple Fresnel shader that outputs to emission so that there is a variable, when a creature gets hit they will flash a certain color based on the element's attack
**Portal Shader**
<img width="905" height="465" alt="image" src="https://github.com/user-attachments/assets/6b888df4-db08-463e-b42e-5102c6b2408c" />
Shader that gets the UV and uses the twirl function in shader graph to create a twisting motion for a portal also changed it so that the portal is slightly transparent.
