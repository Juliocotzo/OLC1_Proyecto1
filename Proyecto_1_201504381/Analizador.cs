using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace Proyecto_1_201504381
{
    class Analizador
    {
        public StringBuilder errores;
        //String valor = "";
        String Variables = "";
        String Metodos = "";
        String extend = "";
        String extend2 = "";
        String nombreClase = "";
        String hola = "";
        String agregacion = "";
        String valores1 = "";
        public String relaciones = "";
        
        //public List<String> instructions = new List<String>();

        public static ArrayList instrucciones = new ArrayList();

        public Analizador()
        {
            this.errores = new StringBuilder();
        }


        public bool analizar(String entrada)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);


            ParseTree arbol = parser.Parse(entrada);

            ParseTreeNode raiz = arbol.Root;

            if (raiz == null || arbol.ParserMessages.Count > 0 || arbol.HasErrors())
            {
                //---------------------> Hay Errores      
                //---------------------> Hay Errores      
                MessageBox.Show("Hay Errores");
                errores.Append("hay errores:\n");
                foreach (var item in arbol.ParserMessages)
                {
                    errores.Append(item.Location.Line + " ");
                    errores.Append(item.Location.Column + " ");
                    errores.Append(item.Message + "\n");
                }
                return false;
            }
            //RecorrerAST(raiz);

            return true;
        }

        public string RecorrerAST(ParseTreeNode Raiz)
        {

            string valor = "";
            switch (Raiz.ToString())
            {
                case "S": //INICIO;
                    valor = RecorrerAST(Raiz.ChildNodes[0]).ToString();
                    break;

                case "INICIO": //AMBITO + clase + id + EXTENDS + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;
                    //valor = RecorrerAST(Raiz.ChildNodes[0]) +" "+ Raiz.ChildNodes[1].Token.Text + " " + Raiz.ChildNodes[2].Token.Text + " " + RecorrerAST(Raiz.ChildNodes[3]).ToString() + " " + Raiz.ChildNodes[4].Token.Text + " " + RecorrerAST(Raiz.ChildNodes[5]).ToString() + " " + Raiz.ChildNodes[6].Token.Text;
                    //valor += "\n\rNombre Clase: " + Raiz.ChildNodes[2].Token.Text +" "+ RecorrerAST(Raiz.ChildNodes[3])+"\n";
                    //valor += RecorrerAST(Raiz.ChildNodes[5]);
                    //nombre_clase[label="{nombre_clase|variable \n |metod"}"]
                    nombreClase = Raiz.ChildNodes[2].Token.Text;
                    valor += Raiz.ChildNodes[2].Token.Text+"[label=\"{"+Raiz.ChildNodes[2].Token.Text+"|"+
                        RecorrerAST(Raiz.ChildNodes[5])+Variables+"|"+Metodos+"}\"] ";
                    RecorrerAST(Raiz.ChildNodes[3]);

                    //valor += extend2;

                    break;

                case "EXTENDS":
                    /* : extiende + id
                     | Empty;*/
                    //valor += Raiz.ChildNodes[0].Token.Text;
                    if (Raiz.ChildNodes.Count==2)
                    {
                        
                        valor = Raiz.ChildNodes[1].Token.Text+"->"+nombreClase ;
                        //Console.WriteLine(valor);
                        instrucciones.Add(valor);


                    }
                    else
                    {
                        //valor += "->" + nombreClase + "[constraint=false, arrowtail=odiamond]";
                    }
                    break;
                case "AMBITO":
                    /* publica
                    | privada
                    | protegido
                    | Empty;*/
                    // valor += Raiz.ChildNodes[0].Token.Text;

                    try
                    {
                        if (Raiz.ChildNodes[0].Token.Text == "public")
                        {
                            valor += "+";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "private")
                        {
                            valor += "-";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "protected")
                        {
                            valor += "#";
                        }
                        else
                        {
                            valor += "+";
                        }
                    }
                    catch
                    {
                        valor += "+";
                    }
                    //valor += "-";
                    break;
                case "INSTRUCCIONES":
                    /*: 
                    INSTRUCCIONES + DECLARACIONES
                   | DECLARACIONES;*/
                    valor = "";
                    if (Raiz.ChildNodes.Count==2)
                    {
                       // valor += "HOLA2";
                        valor += RecorrerAST(Raiz.ChildNodes[0]);
                        valor += RecorrerAST(Raiz.ChildNodes[1]);
                    }
                    else
                    {
                        valor += RecorrerAST(Raiz.ChildNodes[0]);
                    }

                    break;
                case "DECLARACIONES":
                    /*: VARIABLES//------------------DECLARACIONES
                    | CONSTRUCTOR
                    | METODO
                    | FUNCIONES
                    | OVERRIDE
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    if (Raiz.ChildNodes[0].ToString()=="VARIABLES")
                    {
                        Variables += RecorrerAST(Raiz.ChildNodes[0]);
                    }
                    else if (Raiz.ChildNodes[0].ToString() == "CONSTRUCTOR")
                    {
                        Metodos += RecorrerAST(Raiz.ChildNodes[0]) + "\\" + "n";
                        
                    }else if(Raiz.ChildNodes[0].ToString() == "METODO")
                    {
                        Metodos += RecorrerAST(Raiz.ChildNodes[0]) + "\\" + "n";
                    }else if (Raiz.ChildNodes[0].ToString() == "OVERRIDE")
                    {
                        Metodos += RecorrerAST(Raiz.ChildNodes[0]) + "\\" + "n";
                    }
                    else if (Raiz.ChildNodes[0].ToString() == "FUNCIONES")
                    {
                        Metodos += RecorrerAST(Raiz.ChildNodes[0]) + "\\" + "n";
                    }

                    break;

                case "INSTRUCCIONES_FUNCIONES":
                    /*: INSTRUCCIONES_FUNCIONES + DECLARACIONES_FUNCIONES
                   | DECLARACIONES_FUNCIONES;*/


                    break;
                case "DECLARACIONES_FUNCIONES":
                    /*VARIABLES
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_CONSTRUCTOR":
                    /* INSTRUCCIONES_CONSTRUCTOR + DECLARACIONES_CONSTRUCTOR
                    | DECLARACIONES_CONSTRUCTOR;*/
                    break;
                case "DECLARACIONES_CONSTRUCTOR:":
                    /*VARIABLES
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_METODO":
                    /*INSTRUCCIONES_METODO + DECLARACIONES_METODO
                    | DECLARACIONES_METODO;*/
                    break;
                case "DECLARACIONES_METODO":
                    /*VARIABLES//------------------DECLARACIONES METODO

                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_CICLO":
                    /*  : INSTRUCCIONES_CICLO + DECLARACIONES_CICLO
                     | DECLARACIONES_CICLO;*/
                    break;
                case "DECLARACIONES_CICLO":
                    /*: VARIABLES
                            | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/


                    break;
                case "VARIABLES":
                    //-----------------------------------------------------------------------VARIABLES
                    //: AMBITO + TIPO + L_ID + INICIALIZAR;
                    try
                    {
                        /*valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                        RecorrerAST(Raiz.ChildNodes[1]) + " " +
                        RecorrerAST(Raiz.ChildNodes[2]);*/
                        string verificar = RecorrerAST(Raiz.ChildNodes[1]).ToString();
                        if (verificar == "return")
                        {
                            Console.WriteLine("ESTO NO VA AQUI");
                        }
                        valores1 = RecorrerAST(Raiz.ChildNodes[0]) + " " +
                        RecorrerAST(Raiz.ChildNodes[1]) + " ";
                        valor += RecorrerAST(Raiz.ChildNodes[2]) + "\\" + "n";
                    }
                    catch (Exception e)
                    {
                        /*valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                        RecorrerAST(Raiz.ChildNodes[1]) + " " +
                        RecorrerAST(Raiz.ChildNodes[2])+ RecorrerAST(Raiz.ChildNodes[3]);*/
                    }
                    //valor += RecorrerAST(Raiz.ChildNodes[1])+" ";

                    break;
                case "TIPO":
                    /*entero
                    | String
                    | boolean
                    | doble
                    | Char
                    | OBJETO;*/
                    if (Raiz.ChildNodes.Count==1)
                    {
                        /*try
                        {
                            if (Raiz.ChildNodes[0].ToString() == "OBJETO")
                            {
                                valor += RecorrerAST(Raiz.ChildNodes[0]);
                            }
                            else if (Raiz.ChildNodes[0].Token.Text == "int")
                            {
                                valor += "int";
                            }
                            else if (Raiz.ChildNodes[0].Token.Text == "String")
                            {
                                valor += "String";
                            }
                            else if (Raiz.ChildNodes[0].Token.Text == "boolean")
                            {
                                valor += "boolean";
                            }
                            else if (Raiz.ChildNodes[0].Token.Text == "double")
                            {
                                valor += "double";
                            }
                            else if (Raiz.ChildNodes[0].Token.Text == "char")
                            {
                                valor += "char";
                            }
                        }
                        catch
                        {
                            valor += "char";
                        }*/
                        if (Raiz.ChildNodes[0].ToString() == "OBJETO")
                        {
                            valor += RecorrerAST(Raiz.ChildNodes[0]);
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "int")
                        {
                            valor += "int";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "String")
                        {
                            valor += "String";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "boolean")
                        {
                            valor += "boolean";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "double")
                        {
                            valor += "double";
                        }
                        else if (Raiz.ChildNodes[0].Token.Text == "char")
                        {
                            valor += "char";
                        }
                    }


                    break;
                case "L_ID":
                    if (Raiz.ChildNodes.Count==3)
                    {
                        if (Raiz.ChildNodes[1].Token.Text == ",")
                        {
                            valor +=  valores1 + Raiz.ChildNodes[2].Token.Text+"\\"+"n";
                            valor += RecorrerAST(Raiz.ChildNodes[0]);
                        }
                    }else if (Raiz.ChildNodes.Count == 4)
                    {
                        valor += RecorrerAST(Raiz.ChildNodes[0]);
                    }
                    else
                    {
                        valor+= valores1 + Raiz.ChildNodes[0].Token.Text.ToString();
                    }
                    /*L_ID + coma + id
                    | L_ID + punto + id
                    | id
                    | L_ID + mas + mas
                    | L_ID + menos + menos
                    | Empty;*/
                    break;
                case "INICIALIZAR":
                    if (Raiz.ChildNodes.Count == 3)
                    {
                        if (Raiz.ChildNodes[0].Token.Text == "=")
                        {
                            MessageBox.Show("0");

                        }
                        else
                        {
                            MessageBox.Show("1");
                        }
                    }
                    else
                    {
                        MessageBox.Show("00");
                        //valor += Raiz.ChildNodes[0].Token.Text.ToString();
                    }
                    /*puntoycoma
                    | igual + EXPRESION + puntoycoma
                    | igual + nulo + puntoycoma
                    | igual + L_ID + puntoycoma

                    | igual + nuevo + id + parentesisAbierto + PARAMETROS + parentesisCerrado + puntoycoma;*/
                    break;
                case "OBJETO":
                    /*OBJETO + punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | OBJETO + punto + id
                    | punto + id
                    | id
                    | id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | Empty;*/
                    if (Raiz.ChildNodes.Count == 1)
                    {
                        hola = Raiz.ChildNodes[0].Token.Text;
                        /*if (hola!="boolean" && hola!="string")
                        {
                            
                        }*/
                        
                        agregacion = nombreClase + "->" + hola + "[constraint=false, arrowtail=odiamond] ";
                        valor += Raiz.ChildNodes[0].Token.Text.ToString();
                        //Console.WriteLine(agregacion);
                        instrucciones.Add(agregacion);
                    }
                    else
                    {
                        /*hola = Raiz.ChildNodes[0].Token.Text.ToString();
                        agregacion += nombreClase + "->" + hola + "[constraint=false, arrowtail=odiamond] ";
                        valor += Raiz.ChildNodes[0].Token.Text.ToString();*/

                    }

                    break;
                case "EXPRESION":
                    /*EXPRESION + mas + EXPRESION
                        | EXPRESION + menos + EXPRESION
                        | EXPRESION + por + EXPRESION
                        | EXPRESION + division + EXPRESION
                        | EXPRESION + elev + EXPRESION
                        | num
                        | menos + num
                        | menos + id
                        | id
                        | tcadena
                        | OBJETO
                        | parentesisAbierto
                        | parentesisCerrado
                        | EXPRESION + COMPARACION + EXPRESION
                        | EXPRESION + OBJETO;/*
                        //-------------------------------------------------------------------CONSTRUCTOR
                        break;*/
                    case "CONSTRUCTOR":
                    //: AMBITO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CONSTRUCTOR + corcheteCerado;
                    valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                        Raiz.ChildNodes[1].Token.Text + " " +
                        Raiz.ChildNodes[2].Token.Text + "" +
                        RecorrerAST(Raiz.ChildNodes[3]) + " " +
                        Raiz.ChildNodes[4].Token.Text;
                        break;

                    case "PARAMETROS":
                    //valor += "HOLA";
                    /*PARAMETROS + coma + TIPO + id
                    | TIPO + id
                    | PARAMETROS + coma + id
                    | id
                    | PARAMETROS + coma + num
                    | num
                    | tcadena
                    | PARAMETROS + EXPRESION
                    | Empty;*/
                    if (Raiz.ChildNodes.Count==4)
                    {
                        
                            valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +  
                            Raiz.ChildNodes[1].Token.Text + " " + 
                            RecorrerAST(Raiz.ChildNodes[2]) + " " +
                            Raiz.ChildNodes[3].Token.Text;


                    }else if (Raiz.ChildNodes.Count == 2)
                    {
                        if (Raiz.ChildNodes[0].ToString()=="TIPO")
                        {
                            valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                            Raiz.ChildNodes[1].Token.Text;
                        }
                    }else if (Raiz.ChildNodes.Count == 1)
                    {
                        valor += "";
                    }
                    break;
                case "METODO"://------------------------------------------------------------METODO
                              //AMBITO + Void + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;
                    valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                                            Raiz.ChildNodes[1].Token.Text + " " +
                                            Raiz.ChildNodes[2].Token.Text + "" +
                                            Raiz.ChildNodes[3].Token.Text + "" +
                                            RecorrerAST(Raiz.ChildNodes[4]) + " " +
                                            Raiz.ChildNodes[5].Token.Text;
                    
                    //---------------------------------------------------------FUNCIONES
                    break;
                case "FUNCIONES":
                    //AMBITO + TIPO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_FUNCIONES + corcheteCerado;
                    valor += RecorrerAST(Raiz.ChildNodes[0]) + " " +
                                           RecorrerAST(Raiz.ChildNodes[1])+ " " +
                                           Raiz.ChildNodes[2].Token.Text + " " +
                                           Raiz.ChildNodes[3].Token.Text + "" +
                                           RecorrerAST(Raiz.ChildNodes[4]) + " " +
                                           Raiz.ChildNodes[5].Token.Text;
                    //-----------------------------------------------------------------------OVERRIDE
                    break;
                case "OVERRIDE":
                    /*: arroba + ov + METODO
                    | arroba + ov + FUNCIONES;*/
                    //-------------------------------------------------------------ACCESO
                    //ACCESO: L_ID+puntoycoma;
                    //----------------------------------------------------IF
                    if (Raiz.ChildNodes.Count==3)
                    {
                        valor += RecorrerAST(Raiz.ChildNodes[2]);
                    }
                    break;
                case "IF":
                    //si + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + LSEN;

                    break;
                case "CONDICION":
                    //EXPRESION + COMPARACION + EXPRESION + OPLOGICO;

                    break;
                case "COMPARACION":
                    /*: menor
                    | mayor
                    | menorIgual
                    | mayorIgual
                    | dobleIgual
                    | diferente;*/

                    break;
                case "OPLOGICO":
                    /*and + CONDICION
                    | or + CONDICION
                    | not + CONDICION
                    | Empty;*/

                    break;
                case "LSEN":
                    /*: LSEN + sino + ELSE
                    | sino + ELSE
                    | Empty;*/

                    break;
                case "ELSE":
                    /*IF
                    | corcheteAbrierto + INSTRUCCIONES + corcheteCerado;*/
                    //| Empty;
                    /////-------------------------------------------SWITCH
                    break;
                case "SWITCH":
                    //Switch + parentesisAbierto + EXPRESION + parentesisCerrado + corcheteAbrierto + caso + EXPRESION + dospuntos + INSTRUCCIONES_CICLO + freno + puntoycoma + CASO + defa + dospuntos + INSTRUCCIONES + freno + puntoycoma + corcheteCerado;


                    break;
                case "CASO":
                    /*CASO + caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                    | caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                    | Empty;*/
                    //-----------------------------------------------------------WHILE
                    break;
                case "WHILE":
                    //mientras + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;
                    //-------------------------------------------------------DO-WHILE
                    break;
                case "DO":
                    //hacer + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + mientras + parentesisAbierto + CONDICION + parentesisCerrado + puntoycoma;
                    //-------------------------------------------------------FOR
                    break;
                case "FOR":
                    //For + parentesisAbierto + EXPRESION + igual + EXPRESION + puntoycoma + CONDICION + puntoycoma + ASIGNACION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;

                    break;
                case "ASIGNACION":
                    /*: EXPRESION + mas + mas
                    | EXPRESION + menos + menos
                    | EXPRESION + igual + EXPRESION;*/
                    break;
                case "RETURN":
                    /*regresar + puntoycoma
            | regresar + EXPRESION + puntoycoma
            | regresar + EXPRESION + OPLOGICO2;*/

                    break;
                case " OPLOGICO2":
                    /*OPLOGICO2 + and + EXPRESION
                    | OPLOGICO2 + or + EXPRESION
                    | OPLOGICO2 + not + EXPRESION
                    | and + EXPRESION
                    | or + EXPRESION
                    | not + EXPRESION
                    | Empty;*/
                    break;
            }
            return valor;

        }

        public string lista()
        {
            foreach (String item in instrucciones)
            {
                relaciones += item+" ";
            }

            


            Console.WriteLine("hola: " + relaciones);

            return relaciones;
        }

        

        

        public void RecorrerOP(ParseTreeNode nodo)
        {
            switch (nodo.Term.Name)
            {
                case "S": //INICIO;
                    break;

                case "INICIO": //AMBITO + clase + id + EXTENDS + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;
                    break;

                case "EXTENDS":
                    /* : extiende + id
                     | Empty;*/
                    break;
                case "AMBITO":
                    /* publica
                    | privada
                    | protegido
                    | Empty;*/
                    break;
                case "INSTRUCCIONES":
                    /*: 
                    INSTRUCCIONES + DECLARACIONES
                   | DECLARACIONES;*/

                    break;
                case "DECLARACIONES":
                    /*: VARIABLES//------------------DECLARACIONES
                    | CONSTRUCTOR
                    | METODO
                    | FUNCIONES
                    | OVERRIDE
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;/*
                        break;
                    case "INSTRUCCIONES_FUNCIONES":
                    /*: INSTRUCCIONES_FUNCIONES + DECLARACIONES_FUNCIONES
                   | DECLARACIONES_FUNCIONES;*/


                    break;
                case "DECLARACIONES_FUNCIONES":
                    /*VARIABLES
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_CONSTRUCTOR":
                    /* INSTRUCCIONES_CONSTRUCTOR + DECLARACIONES_CONSTRUCTOR
                    | DECLARACIONES_CONSTRUCTOR;*/
                    break;
                case "DECLARACIONES_CONSTRUCTOR:":
                    /*VARIABLES
                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_METODO":
                    /*INSTRUCCIONES_METODO + DECLARACIONES_METODO
                    | DECLARACIONES_METODO;*/
                    break;
                case "DECLARACIONES_METODO":
                    /*VARIABLES//------------------DECLARACIONES METODO

                    | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/
                    break;
                case "INSTRUCCIONES_CICLO":
                    /*  : INSTRUCCIONES_CICLO + DECLARACIONES_CICLO
                     | DECLARACIONES_CICLO;*/
                    break;
                case "DECLARACIONES_CICLO":
                    /*: VARIABLES
                            | IF
                    | SWITCH
                    | WHILE
                    | DO
                    | FOR
                    | RETURN//------componer los parentesis
                    | freno + puntoycoma
                    | continuar + puntoycoma;*/


                    break;
                case "VARIABLES":
                    //-----------------------------------------------------------------------VARIABLES
                    //: AMBITO + TIPO + L_ID + INICIALIZAR;

                    break;
                case "TIPO":
                    /*entero
                    | String
                    | boolean
                    | doble
                    | Char
                    | OBJETO;*/


                    break;
                case "L_ID":
                    /*L_ID + coma + id
                    | L_ID + punto + id
                    | id
                    | L_ID + mas + mas
                    | L_ID + menos + menos
                    | Empty;*/
                    break;
                case "INICIALIZAR":
                    /*puntoycoma
                    | igual + EXPRESION + puntoycoma
                    | igual + nulo + puntoycoma
                    | igual + L_ID + puntoycoma

                    | igual + nuevo + id + parentesisAbierto + PARAMETROS + parentesisCerrado + puntoycoma;*/
                    break;
                case "OBJETO":
                    /*OBJETO + punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | OBJETO + punto + id
                    | punto + id
                    | id
                    | id + parentesisAbierto + PARAMETROS + parentesisCerrado
                    | Empty;*/

                    break;
                case "EXPRESION":
                    /*EXPRESION + mas + EXPRESION
                        | EXPRESION + menos + EXPRESION
                        | EXPRESION + por + EXPRESION
                        | EXPRESION + division + EXPRESION
                        | EXPRESION + elev + EXPRESION
                        | num
                        | menos + num
                        | menos + id
                        | id
                        | tcadena
                        | OBJETO
                        | parentesisAbierto
                        | parentesisCerrado
                        | EXPRESION + COMPARACION + EXPRESION
                        | EXPRESION + OBJETO;/*
                        //-------------------------------------------------------------------CONSTRUCTOR
                        break;
                    case "CONSTRUCTOR":
                    //: AMBITO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CONSTRUCTOR + corcheteCerado;

                        break;
                    case "PARAMETROS":
                    /*PARAMETROS + coma + TIPO + id
                    | TIPO + id
                    | PARAMETROS + coma + id
                    | id
                    | PARAMETROS + coma + num
                    | num
                    | tcadena
                    | PARAMETROS + EXPRESION
                    | Empty;*/
                    break;
                case "METODO"://------------------------------------------------------------METODO
                              //AMBITO + Void + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;

                    //---------------------------------------------------------FUNCIONES
                    break;
                case "FUNCIONES":
                    //AMBITO + TIPO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_FUNCIONES + corcheteCerado;
                    //-----------------------------------------------------------------------OVERRIDE
                    break;
                case "OVERRIDE":
                    /*: arroba + ov + METODO
                    | arroba + ov + FUNCIONES;*/
                    //-------------------------------------------------------------ACCESO
                    //ACCESO: L_ID+puntoycoma;
                    //----------------------------------------------------IF
                    break;
                case "IF":
                    //si + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + LSEN;

                    break;
                case "CONDICION":
                    //EXPRESION + COMPARACION + EXPRESION + OPLOGICO;

                    break;
                case "COMPARACION":
                    /*: menor
                    | mayor
                    | menorIgual
                    | mayorIgual
                    | dobleIgual
                    | diferente;*/

                    break;
                case "OPLOGICO":
                    /*and + CONDICION
                    | or + CONDICION
                    | not + CONDICION
                    | Empty;*/

                    break;
                case "LSEN":
                    /*: LSEN + sino + ELSE
                    | sino + ELSE
                    | Empty;*/

                    break;
                case "ELSE":
                    /*IF
                    | corcheteAbrierto + INSTRUCCIONES + corcheteCerado;*/
                    //| Empty;
                    /////-------------------------------------------SWITCH
                    break;
                case "SWITCH":
                    //Switch + parentesisAbierto + EXPRESION + parentesisCerrado + corcheteAbrierto + caso + EXPRESION + dospuntos + INSTRUCCIONES_CICLO + freno + puntoycoma + CASO + defa + dospuntos + INSTRUCCIONES + freno + puntoycoma + corcheteCerado;


                    break;
                case "CASO":
                    /*CASO + caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                    | caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                    | Empty;*/
                    //-----------------------------------------------------------WHILE
                    break;
                case "WHILE":
                    //mientras + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;
                    //-------------------------------------------------------DO-WHILE
                    break;
                case "DO":
                    //hacer + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + mientras + parentesisAbierto + CONDICION + parentesisCerrado + puntoycoma;
                    //-------------------------------------------------------FOR
                    break;
                case "FOR":
                    //For + parentesisAbierto + EXPRESION + igual + EXPRESION + puntoycoma + CONDICION + puntoycoma + ASIGNACION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;

                    break;
                case "ASIGNACION":
                    /*: EXPRESION + mas + mas
                    | EXPRESION + menos + menos
                    | EXPRESION + igual + EXPRESION;*/
                    break;
                case "RETURN":
                    /*regresar + puntoycoma
            | regresar + EXPRESION + puntoycoma
            | regresar + EXPRESION + OPLOGICO2;*/

                    break;
                case " OPLOGICO2":
                    /*OPLOGICO2 + and + EXPRESION
                    | OPLOGICO2 + or + EXPRESION
                    | OPLOGICO2 + not + EXPRESION
                    | and + EXPRESION
                    | or + EXPRESION
                    | not + EXPRESION
                    | Empty;*/
                    break;
            }

        }
    }
}


       

        
        

       