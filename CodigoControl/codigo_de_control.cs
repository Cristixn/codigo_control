using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventario
{
    public partial class codigo_de_control : Form
    {
        public codigo_de_control()
        {
            InitializeComponent();
        }
        string dia = "", mes = "", anio = "", fecha_aux = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            decimal numero_1 = 0;
            int numero_2 = 0;
            string aux = "";
            aux = Convert.ToString(txt_monto.Text);
            numero_1 = Convert.ToDecimal(txt_monto.Text);
            string texto = Convert.ToString(numero_1);
            texto = texto.Replace(",", ".");
            numero_2 = Convert.ToInt32(numero_1);
            txt_monto.Text = "";
            txt_monto.Text = Convert.ToString(numero_2);

            fecha_final = "";
            fecha = "";
            //fecha
            try {
            fecha = Convert.ToString(txt_fecha.Text);
            txt_fecha.Text = "";
            dia = ""; mes = ""; anio = ""; fecha_aux = "";
            anio = fecha.Substring(0, 4);
            mes = fecha.Substring(5, 2);
            dia = fecha.Substring(8, 2);
            fecha_aux = anio + mes + dia;
            txt_fecha.Text = Convert.ToString(fecha_aux);
            fecha_final = fecha_aux;
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            genera_codigo_control();
            qrCodeImgControl1.Text = "";
            txt_codigo_final.Text = "";
            txt_fecha.Text = Convert.ToString(fecha);
            txt_monto.Text = Convert.ToString(aux);

            fecha_final = fecha;
            qrCodeImgControl1.Text = txt_nit_empresa.Text + "|" + txt_factura.Text + "|" + txt_autorizacion.Text + "|" + fecha_final + "|" + texto + "|" + texto + "|" + lbl_codigo_de_control.Text + "|" + txt_cliente.Text + "|0.00" + "|0.00" + "|0.00" + "|0.00";
            txt_codigo_final.Text = txt_nit_empresa.Text + "|" + txt_factura.Text + "|" + txt_autorizacion.Text + "|" + fecha_final + "|" + texto + "|" + texto + "|" + lbl_codigo_de_control.Text + "|" + txt_cliente.Text; ;
            }
            catch (Exception ex) { 
                MessageBox.Show("Verifique los datos"+ex.Message); 
            }
        }
        string fecha, fecha_final = "";
        private void codigo_de_control_Load(object sender, EventArgs e)
        {
        }
        string monto = "";
        public void genera_codigo_control()
        {
            try
            {
                txt_factura.Text = txt_factura.Text.Trim();
                if (txt_factura.Text.Length > 0)
                {
                    string numero_factura = VerhoeffCheckDigit.AppendCheckDigit(txt_factura.Text).ToString();
                    txt_factura_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(numero_factura).ToString();
                    string numero_cliente = VerhoeffCheckDigit.AppendCheckDigit(txt_cliente.Text).ToString();
                    txt_cliente_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(numero_cliente).ToString();
                    string fecha = VerhoeffCheckDigit.AppendCheckDigit(txt_fecha.Text).ToString();
                    txt_fecha_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(fecha).ToString();
                    double nd = Convert.ToDouble(txt_monto.Text);
                    int nc = Convert.ToInt32(nd);
                    string monto1 = Convert.ToString(nc);
                    monto = VerhoeffCheckDigit.AppendCheckDigit(monto1).ToString();
                    txt_monto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(monto).ToString();
                    double int_factura = Convert.ToDouble(txt_factura_veroef.Text);
                    double int_cliente = Convert.ToDouble(txt_cliente_veroef.Text);
                    double int_fecha = Convert.ToDouble(txt_fecha_veroef.Text);
                    double int_monto = Convert.ToDouble(txt_monto_veroef.Text);
                    double total = int_factura + int_cliente + int_fecha + int_monto;
                    txt_auto_veroef.Text = Convert.ToString(total);
                    txt_auto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(txt_auto_veroef.Text).ToString();
                    txt_auto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(txt_auto_veroef.Text).ToString();
                    txt_auto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(txt_auto_veroef.Text).ToString();
                    txt_auto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(txt_auto_veroef.Text).ToString();
                    txt_auto_veroef.Text = VerhoeffCheckDigit.AppendCheckDigit(txt_auto_veroef.Text).ToString();
                    string longitud = txt_auto_veroef.Text.Length.ToString();
                    int largo_cadena = Convert.ToInt32(longitud);
                    string cadena_verloef = Convert.ToString(txt_auto_veroef.Text);
                    string verloef_final = cadena_verloef.Substring(largo_cadena - 5, 5);
                    txt_resultado_verlof.Text = verloef_final;
                    string verloef_1 = verloef_final.Substring(0, 1);
                    int numero_1 = Convert.ToInt16(verloef_1);
                    numero_1++;
                    string verloef_2 = verloef_final.Substring(1, 1);
                    int numero_2 = Convert.ToInt16(verloef_2);
                    numero_2++;
                    string verloef_3 = verloef_final.Substring(2, 1);
                    int numero_3 = Convert.ToInt16(verloef_3);
                    numero_3++;
                    string verloef_4 = verloef_final.Substring(3, 1);
                    int numero_4 = Convert.ToInt16(verloef_4);
                    numero_4++;
                    string verloef_5 = verloef_final.Substring(4, 1);
                    int numero_5 = Convert.ToInt16(verloef_5);
                    numero_5++;
                    txt_valorincrementado.Text = Convert.ToString(numero_1) + Convert.ToString(numero_2) + Convert.ToString(numero_3) + Convert.ToString(numero_4) + Convert.ToString(numero_5);
                    string autorizacion_llave = txt_autorizacion.Text + txt_llsve_dosificacion.Text.Substring(0, numero_1) + txt_factura_veroef.Text + txt_llsve_dosificacion.Text.Substring(numero_1, numero_2) + txt_cliente_veroef.Text + txt_llsve_dosificacion.Text.Substring(numero_1 + numero_2, numero_3) + txt_fecha_veroef.Text + txt_llsve_dosificacion.Text.Substring(numero_1 + numero_2 + numero_3, numero_4) + txt_monto_veroef.Text + txt_llsve_dosificacion.Text.Substring(numero_1 + numero_2 + numero_3 + numero_4, numero_5);
                    txt_llaves_agregadas.Text = autorizacion_llave;
                    string llave = Convert.ToString(txt_llsve_dosificacion.Text) + Convert.ToString(txt_resultado_verlof.Text);
                    allerecedrc4(Convert.ToString(txt_llaves_agregadas.Text), llave);
                    cadena = Convert.ToString(txt_allereced.Text);
                    int sparcial_1 = 0, sparcial_2 = 0, sparcial_3 = 0, sparcial_4 = 0, sparcial_5 = 0;
                    int parcial_1 = 0, parcial_2 = 0, parcial_3 = 0, parcial_4 = 0, parcial_5 = 0;
                    int cont1 = 0, cont2 = 1, cont3 = 2, cont4 = 3, cont5 = 4;
                    byte[] array = Encoding.ASCII.GetBytes(cadena);
                    int sumatoria = 0;
                    foreach (byte element in array)
                    {
                        sumatoria = sumatoria + (char)element;
                    }
                    foreach (byte element in array)
                    {
                        while (cont1 == parcial_1)
                        {
                            sparcial_1 = sparcial_1 + (char)element;
                            cont1 = cont1 + 5;
                        }
                        parcial_1++;
                        while (cont2 == parcial_2)
                        {
                            sparcial_2 = sparcial_2 + (char)element;
                            cont2 = cont2 + 5;
                        }
                        parcial_2++;
                        while (cont3 == parcial_3)
                        {
                            sparcial_3 = sparcial_3 + (char)element;
                            cont3 = cont3 + 5;
                        }
                        parcial_3++;
                        while (cont4 == parcial_4)
                        {
                            sparcial_4 = sparcial_4 + (char)element;
                            cont4 = cont4 + 5;
                        }
                        parcial_4++;
                        while (cont5 == parcial_5)
                        {
                            sparcial_5 = sparcial_5 + (char)element;
                            cont5 = cont5 + 5;
                        }
                        parcial_5++;
                        txt_sumatoria_1.Text = Convert.ToString(sparcial_1);
                        txt_sumatoria_2.Text = Convert.ToString(sparcial_2);
                        txt_sumatoria_3.Text = Convert.ToString(sparcial_3);
                        txt_sumatoria_4.Text = Convert.ToString(sparcial_4);
                        txt_sumatoria_5.Text = Convert.ToString(sparcial_5);
                        int suma_1 = sumatoria * sparcial_1;
                        suma_1 = suma_1 / numero_1;
                        int suma_2 = sumatoria * sparcial_2;
                        suma_2 = suma_2 / numero_2;
                        int suma_3 = sumatoria * sparcial_3;
                        suma_3 = suma_3 / numero_3;
                        int suma_4 = sumatoria * sparcial_4;
                        suma_4 = suma_4 / numero_4;
                        int suma_5 = sumatoria * sparcial_5;
                        suma_5 = suma_5 / numero_5;
                        int suma_final = suma_1 + suma_2 + suma_3 + suma_4 + suma_5;
                        txt_sumatoria_final.Text = Convert.ToString(suma_final);
                        txt_sumatoria_11.Text = base64(Convert.ToInt32(txt_sumatoria_final.Text));
                        //APLICAMOS ALLEGEDRC4 PARA EL CODIGO DE CONTROL FINAL
                        string llave_final = Convert.ToString(txt_llsve_dosificacion.Text) + verloef_final;
                        alleged2(Convert.ToString(txt_sumatoria_11.Text), llave_final);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = (Image)qrCodeImgControl1.Image.Clone();
            SaveFileDialog sv = new SaveFileDialog();
            sv.AddExtension = true;
            sv.Filter = "IMAGE jpg(*.jpg)|*.jpg";
            sv.ShowDialog();
            if (!string.IsNullOrEmpty(sv.FileName))
            {
                img.Save(sv.FileName);
            }
        }
        public void allerecedrc4(string codigo, string llavellegada)
        {
            int[] State = new int[256 + 1];
            string mensaje = string.Empty;
            string llave = string.Empty;
            string MsgCif = string.Empty;
            int x = 0;
            int y = 0;
            int index1 = 0;
            int index2 = 0;
            int NMen = 0;
            int i = 0;
            short op1 = 0;
            int aux = 0;
            int op2 = 0;
            string nrohex = string.Empty;

            x = 0;
            y = 0;
            index1 = 0;
            index2 = 0;
            mensaje = codigo;
            llave = llavellegada;
            for (i = 0; i <= 255.0; i++)
            {
                State[i] = i;
            }
            for (i = 0; i <= 255.0; i++)
            {
                op1 = (short)(llave.Substring(index1 + 1 - 1, 1)[0]);
                index2 = (op1 + State[i] + index2) % 256;
                aux = State[i];
                State[i] = State[index2];
                State[index2] = aux;
                index1 = (index1 + 1) % llave.Length;
            }
            for (i = 0; i <= mensaje.Length - 1; i += 1)
            {
                x = (x + 1) % 256;
                y = (State[x] + y) % 256;
                aux = State[x];
                State[x] = State[y];
                State[y] = aux;
                op1 = (short)(mensaje.Substring(i + 1 - 1, 1)[0]);
                op2 = State[(State[x] + State[y]) % 256];
                NMen = op1 ^ op2;
                nrohex = NMen.ToString("X");
                if (nrohex.Length == 1)
                {
                    nrohex = "0" + nrohex;
                }
                MsgCif = MsgCif + nrohex;
            }
            MsgCif = MsgCif.Substring(MsgCif.Length - (MsgCif.Length));
            txt_allereced.Text = MsgCif;
        }
        //ALLEGED 2 
        public void alleged2(string codigo, string llavellegada)
        {
            int[] State = new int[256 + 1];
            string mensaje = string.Empty;
            string llave = string.Empty;
            string MsgCif = string.Empty;
            int x = 0;
            int y = 0;
            int index1 = 0;
            int index2 = 0;
            int NMen = 0;
            int i = 0;
            short op1 = 0;
            int aux = 0;
            int op2 = 0;
            string nrohex = string.Empty;

            x = 0;
            y = 0;
            index1 = 0;
            index2 = 0;
            mensaje = codigo;
            llave = llavellegada;
            for (i = 0; i <= 255.0; i++)
            {
                State[i] = i;
            }
            for (i = 0; i <= 255.0; i++)
            {
                op1 = (short)(llave.Substring(index1 + 1 - 1, 1)[0]);
                index2 = (op1 + State[i] + index2) % 256;
                aux = State[i];
                State[i] = State[index2];
                State[index2] = aux;
                index1 = (index1 + 1) % llave.Length;
            }
            for (i = 0; i <= mensaje.Length - 1; i += 1)
            {
                x = (x + 1) % 256;
                y = (State[x] + y) % 256;
                aux = State[x];
                State[x] = State[y];
                State[y] = aux;
                op1 = (short)(mensaje.Substring(i + 1 - 1, 1)[0]);
                op2 = State[(State[x] + State[y]) % 256];
                NMen = op1 ^ op2;
                nrohex = NMen.ToString("X");
                if (nrohex.Length == 1)
                {
                    nrohex = "0" + nrohex;
                }
                MsgCif = MsgCif + nrohex;
            }
            MsgCif = MsgCif.Substring(MsgCif.Length - (MsgCif.Length));

            string largo = MsgCif.Length.ToString();
            int lon = Convert.ToInt32(largo);
            string nuevo = "";
            int cont = 0;
            for (int a = 0; a < lon; a = a + 2)
            {
                nuevo = nuevo + MsgCif.Substring(a, 2);
                if (cont + 2 < lon)
                {
                    nuevo = nuevo + "-";
                    cont = cont + 2;
                }


            }
            lbl_codigo_de_control.Text = nuevo;
        }
        string cadena = "";
        public void contar_ascii()
        {
            cadena = Convert.ToString(txt_allereced.Text);
            int sparcial_1 = 0, sparcial_2 = 0, sparcial_3 = 0, sparcial_4 = 0, sparcial_5 = 0;
            int parcial_1 = 0, parcial_2 = 0, parcial_3 = 0, parcial_4 = 0, parcial_5 = 0;
            int cont1 = 0, cont2 = 1, cont3 = 2, cont4 = 3, cont5 = 4;
            byte[] array = Encoding.ASCII.GetBytes(cadena);
            int sumatoria = 0;
            foreach (byte element in array)
            {
                sumatoria = sumatoria + (char)element;
            }
            foreach (byte element in array)
            {
                while (cont1 == parcial_1)
                {
                    sparcial_1 = sparcial_1 + (char)element;
                    cont1 = cont1 + 5;
                }
                parcial_1++;
                while (cont2 == parcial_2)
                {
                    sparcial_2 = sparcial_2 + (char)element;
                    cont2 = cont2 + 5;
                }
                parcial_2++;
                while (cont3 == parcial_3)
                {
                    sparcial_3 = sparcial_3 + (char)element;
                    cont3 = cont3 + 5;
                }
                parcial_3++;
                while (cont4 == parcial_4)
                {
                    sparcial_4 = sparcial_4 + (char)element;
                    cont4 = cont4 + 5;
                }
                parcial_4++;
                while (cont5 == parcial_5)
                {
                    sparcial_5 = sparcial_5 + (char)element;
                    cont5 = cont5 + 5;
                }
                parcial_5++;
                txt_sumatoria_1.Text = Convert.ToString(sparcial_1);
                txt_sumatoria_2.Text = Convert.ToString(sparcial_2);
                txt_sumatoria_3.Text = Convert.ToString(sparcial_3);
                txt_sumatoria_4.Text = Convert.ToString(sparcial_4);
                int suma_1 = sumatoria * sparcial_1;
                int suma_2 = sumatoria * sparcial_2;
                int suma_3 = sumatoria * sparcial_3;
                int suma_4 = sumatoria * sparcial_4;
                int suma_5 = sumatoria * sparcial_5;
                int suma_final = suma_1 + suma_2 + suma_3 + suma_4 + suma_5;
                txt_sumatoria_5.Text = Convert.ToString(suma_1);

            }
        }
        string[] diccionario = new string[64]
        {
        "0","1","2","3","4","5","6","7","8","9",
        "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","+","/",
        };
        public string base64(int numero)
        {
            int cociente = 1; int resto; string palabra = "";
            while (cociente > 0)
            {
                cociente = numero / 64;
                resto = numero % 64;
                palabra = diccionario[resto] + palabra;
                numero = cociente;
            }
            return (palabra);
        }

        private void btn_limpiar_textos_Click(object sender, EventArgs e)
        {
            txt_allereced.Text = "";
            txt_auto_veroef.Text = "";
            txt_autorizacion.Text = "";
            txt_cliente.Text = "";
            txt_cliente_veroef.Text = "";
            txt_codigo_final.Text = "";
            txt_factura.Text = "";
            txt_factura_veroef.Text = "";
            txt_fecha.Text = "";
            txt_fecha_veroef.Text = "";
            txt_llaves_agregadas.Text = "";
            txt_llsve_dosificacion.Text = "";
            txt_monto.Text = "";
            txt_monto_veroef.Text = "";
            txt_resultado_verlof.Text = "";
            txt_sumatoria_1.Text = "";
            txt_sumatoria_11.Text = "";
            txt_sumatoria_2.Text = "";
            txt_sumatoria_3.Text = "";
            txt_sumatoria_4.Text = "";
            txt_sumatoria_5.Text = "";
            txt_sumatoria_final.Text = "";
            txt_valorincrementado.Text = "";
            lbl_codigo_de_control.Text = "CODIGO DE CONTROL";
        }
    }
}
