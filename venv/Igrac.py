xboundary=100
yboundary=100
debljina=20
class Igrac:
    topspeed=20
    def __init__(self,x,y,team,vx=0,vy=0,id=0):
        self.x=x
        self.y=y
        self.vx=vx
        self.vy=vy
        self.team = team
        self.id=id
        self.ima_loptu=False
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
    def __init__(self,x,y,team=None,posed=None):
        self.x=x
        self.y=y
        self.vx=0
        self.vy=0
        self.team=team
        self.posed=posed

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
        return self.posed
    def determine_posed(self,igraci):
        kandidat=None
        mindist=debljina
        for igrac in igraci:
            dist=igrac.dist(self.x,self.y)
            if dist<mindist:
                mindist=dist
                kandidat=igrac
            if dist==mindist:
                if self.team==igrac.team:
                    mindist = dist
                    kandidat = igrac
                    print("konflikt za loptu!")
        print(mindist, "mindist")
        if kandidat is not None:
            print("")
            print("dajem loptu ",end="")
            kandidat.napisi()
            print("")
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



lopta=Lopta(10,10)
igraci=[]
Mitro = Igrac(50.5,90,team=-1,vx=-1,vy=-2)
Vlaho = Igrac(11,11,team=1,vx=0,vy=0)
igraci.append(Mitro)
igraci.append(Vlaho)

def redosled(igraci,lopta):
    print("\n\n\nnovi potez")
    for igrac in igraci:
        #igrac.ima_loptu=False
        #print("pozeri:", igrac.ima_loptu)
        igrac.move()
    lopta.tick_and_posed(igraci)
    for igrac in igraci:
        igrac.odluci_sledeci()
        igrac.broad()
        igrac.napisi()
        #print(igrac)

for i in range(0,50):
    redosled(igraci,lopta)