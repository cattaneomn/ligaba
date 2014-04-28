using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.Clases_LigaBA
{
    public class JugadorXPartido
    {
        private int id;
        private int cantGoles;
        private int cantAmarillas;
        private int cantRojas;

        public JugadorXPartido(int id,int cantGoles, int cantAmarillas, int cantRojas)
        {
            this.id = id;
            this.cantGoles = cantGoles;
            this.cantAmarillas = cantAmarillas;
            this.cantRojas = cantRojas;
        }

        public int get_id() { return id; }
        public int get_cantGoles() { return cantGoles; }
        public int get_cantAmarillas() { return cantAmarillas; }
        public int get_cantRojas() { return cantRojas; }

        public void set_id(int id) {  this.id = id; }
        public void sumar_cantGoles(int cantGoles) { this.cantGoles = this.cantGoles + cantGoles; }
        public void sumar_cantAmarillas(int cantAmarillas) { this.cantAmarillas = this.cantAmarillas + cantAmarillas; }
        public void sumar_cantRojas(int cantRojas) { this.cantRojas = cantRojas; }

        public void restar_cantGoles(int cantGoles) { this.cantGoles = this.cantGoles - cantGoles; }
        public void restar_cantAmarillas(int cantAmarillas) { this.cantAmarillas = this.cantAmarillas - cantAmarillas; }
        public void restar_cantRojas(int cantRojas) { this.cantRojas = this.cantRojas - cantRojas; }
    }
}
