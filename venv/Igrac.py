xboundary=100
yboundary=100
debljina=20
class Igrac:
    topspeed=20
    def __init__(self,x,y,team,vx=0,vy=0,id=0,message=""):
        self.x=x
        self.y=y
        self.vx=vx
        self.vy=vy
        self.team = team
        self.id=id
        self.ima_loptu=False
        self.message=message
    def napisi(self):
        print(self.x,self.y,self.vx,self.vy)

        if self.ima_loptu:
            print(f'na kraju poteza {self.x},{self.y} ima loptu. ')
    def move(self):
        '''
        oduzima sebi loptu i pomera se. treba da bude na pocetku poteza.
        '''
        self.ima_loptu=False
        if self.vx>Igrac.topspeed:
            raise Exception("topspeed")
        if self.vy>Igrac.topspeed:
            raise Exception("topspeed")

        px=self.x+self.vx
        py=self.y+self.vy

        bx,by=Igrac.bounded(px,py)

        self.x=bx
        self.y=by

        #self.surroundings_check()
    def vec(self,bx,by):
        return bx-self.x, by-self.y
    def dist(self,bx,by):
        dx,dy=self.vec(bx,by)
        return (dx*dx+dy*dy)**0.5
    def dobio_loptu(self):
        self.ima_loptu = True

    def odluci_sledeci(self):
        pass
    def broad(self):
        pass
    @staticmethod
    def bounded(x,y):
        bx=x
        by=y
        if x<0:
            bx=0
        if x>xboundary:
            bx=xboundary
        if y<0:
            by=0
        if y>yboundary:
            by=yboundary
        return bx,by

class Lopta:
    topspeed=100
    def __init__(self,x,y,team=None,vlasnik=None):
        self.x=x
        self.y=y
        self.vx=0
        self.vy=0
        self.team=team
        self.vlasnik=vlasnik

    def napisi(self):
        print(f'lopta je na {self.x},{self.y}')

    def tick_and_posed(self,igraci):
        if self.vx>Lopta.topspeed:
            raise Exception("topspeed")
        if self.vy>Lopta.topspeed:
            raise Exception("topspeed")

        px=self.x+self.vx
        py=self.y+self.vy

        bx,by=Lopta.bounded(px,py)

        self.x=bx
        self.y=by

        novi_igrac_sa_posed=self.determine_posed(igraci)
        if (novi_igrac_sa_posed) is not None:

            (novi_igrac_sa_posed).dobio_loptu()
        return self.vlasnik
    def determine_posed(self,igraci):
        kandidat=None
        mindist=debljina
        for igrac in igraci:
            dist=igrac.dist(self.x,self.y)
            if dist<mindist:
                mindist=dist
                kandidat=igrac
            elif dist==mindist:
                if not self.team==igrac.team:
                    mindist = dist
                    kandidat = igrac
                    print("konflikt za loptu!")
        #print(mindist, "mindist")
        if kandidat is not None:
            pass
            #print("")
            #print("dajem loptu ",end="")
            #kandidat.napisi()
            #print("")
        return kandidat


    @staticmethod
    def bounded(x, y):
        bx = x
        by = y
        if x < 0:
            bx = 0
        if x > xboundary:
            bx = xboundary
        if y < 0:
            by = 0
        if y > yboundary:
            by = yboundary
        return bx, by

def initial_instructions():
    with open(fname,"w") as file:
        pass


def write_instructions(igraci,lopta,i):
    with open(fname,"a") as file:
        file.write("potez\n"+str(i))
        file.write("\n")
        file.write(str(len(igraci)))
        file.write("\n")
        file.write(f'{lopta.x} {lopta.y} \n')
        if lopta.team is None:
            file.write("0")
        else:
            file.write(str(lopta.team))
        file.write("\n")
        
        for igrac in igraci:
            file.write(str(igrac.id)+"\n")
            file.write(str(igrac.team)+"\n")
            file.write(f'{igrac.x} {igrac.y} \n')
            file.write(str(igrac.message))
            file.write("\n")
            file.write("1\n" if (igrac.ima_loptu) else "0\n")
            file.write("\n")

            


def redosled(igraci,lopta,i,draw):
    #print("\n\n\nnovi potez")
    for igrac in igraci:
        #igrac.ima_loptu=False
        #print("pozeri:", igrac.ima_loptu)
        igrac.move()
    lopta.tick_and_posed(igraci)
    if draw:
        write_instructions(igraci, lopta,i)
    for igrac in igraci:
        igrac.odluci_sledeci()
        igrac.broad()
        #igrac.napisi()
        #print(igrac)


draw=True
fname="..\\Bonkball\\Bonkball\\Bonkball\\bin\\Debug\\instructions.txt"
lopta=Lopta(10,10)
igraci=[]
initial_instructions()
Mitro = Igrac(50.5,90,team=-1,vx=-1,vy=-2,message="M")
Vlaho = Igrac(11,11,team=1,vx=0,vy=0)
igraci.append(Mitro)
igraci.append(Vlaho)

for i in range(0,10000):
    redosled(igraci,lopta,i,draw)