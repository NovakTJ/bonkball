import numpy as np
with open("..\\Bonkball\\Bonkball\\Bonkball\\bin\\Debug\\instructions.txt","w") as f:
    x=np.zeros(3)
    f.write(f"{x[0]-2,2}\n")
    f.write("1,1\n")