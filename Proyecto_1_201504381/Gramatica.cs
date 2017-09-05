using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;

namespace Proyecto_1_201504381
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(true) { //True es Case Sensitive - False es No Case Sensitive
            
            #region ER
            IdentifierTerminal id = new IdentifierTerminal("id");
            NumberLiteral num = new NumberLiteral("num");
            // RegexBasedTerminal num = new RegexBasedTerminal("num", "[0-9]+");
            // RegexBasedTerminal id = new RegexBasedTerminal("id", "([0-9a-zA-Z]|_)+");
            RegexBasedTerminal objeto = new RegexBasedTerminal("objeto", "[a-zA-Z]([0-9a-zA-Z]|_)*");
            // RegexBasedTerminal metodo = new RegexBasedTerminal("metodo", ".[a-zA-Z]([0-9a-zA-Z]|_)*()");
            StringLiteral tcadena = new StringLiteral("cadena", "\"");
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n");
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "/**", "**/");
            NonGrammarTerminals.Add(comentarioBloque);
            NonGrammarTerminals.Add(comentarioLinea);
            #endregion

            #region Terminals
            KeyTerm clase = ToTerm("class");
            KeyTerm corcheteAbrierto = ToTerm("{");
            KeyTerm corcheteCerado = ToTerm("}");
            KeyTerm publica = ToTerm("public");
            KeyTerm privada = ToTerm("private");
            KeyTerm protegido = ToTerm("protected");
            KeyTerm extiende = ToTerm("extends");
            KeyTerm entero = ToTerm("int");
            KeyTerm String = ToTerm("String");
            KeyTerm boolean = ToTerm("boolean");
            KeyTerm doble = ToTerm("double");
            KeyTerm Char = ToTerm("char");
            KeyTerm coma = ToTerm(",");
            KeyTerm puntoycoma = ToTerm(";");
            KeyTerm parentesisAbierto = ToTerm("(");
            KeyTerm parentesisCerrado = ToTerm(")");
            KeyTerm punto = ToTerm(".");
            KeyTerm mas = ToTerm("+");
            KeyTerm menos = ToTerm("-");
            KeyTerm por = ToTerm("*");
            KeyTerm division = ToTerm("/");
            KeyTerm elev = ToTerm("^");
            KeyTerm igual = ToTerm("=");
            //KeyTerm objeto = ToTerm("objeto");
            KeyTerm nuevo = ToTerm("new");
            KeyTerm nulo = ToTerm("null");
            KeyTerm Void = ToTerm("void");
            KeyTerm arroba = ToTerm("@");
            KeyTerm ov = ToTerm("Override");
            KeyTerm This = ToTerm("this");
            KeyTerm si = ToTerm("if");
            KeyTerm verdad = ToTerm("true");
            KeyTerm falso = ToTerm("false");
            KeyTerm mayor = ToTerm(">");
            KeyTerm menor = ToTerm("<");
            KeyTerm menorIgual = ToTerm("<=");
            KeyTerm mayorIgual = ToTerm(">=");
            KeyTerm dobleIgual = ToTerm("==");
            KeyTerm diferente = ToTerm("!=");
            KeyTerm and = ToTerm("&&");
            KeyTerm or = ToTerm("||");
            KeyTerm not = ToTerm("!");
            KeyTerm sino = ToTerm("else");
            KeyTerm osi = ToTerm("else if");
            KeyTerm Switch = ToTerm("switch");
            KeyTerm caso = ToTerm("case");
            KeyTerm dospuntos = ToTerm(":");
            KeyTerm freno = ToTerm("break");
            KeyTerm defa = ToTerm("default");
            KeyTerm mientras = ToTerm("while");
            KeyTerm hacer = ToTerm("do");
            KeyTerm For = ToTerm("for");
            KeyTerm regresar = ToTerm("return");
            KeyTerm continuar = ToTerm("continue");
            #endregion
            
            #region Non-Terminals 
            NonTerminal S = new NonTerminal("S");
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal AMBITO = new NonTerminal("AMBITO");
            NonTerminal EXTENDS = new NonTerminal("EXTENDS");
            NonTerminal INSTRUCCIONES = new NonTerminal("INSTRUCCIONES");
            NonTerminal DECLARACIONES = new NonTerminal("DECLARACIONES");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal VARIABLES = new NonTerminal("VARIABLES");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal INICIALIZAR = new NonTerminal("INICIALIZAR");
            NonTerminal L_ID = new NonTerminal("L_ID");
            NonTerminal OBJETO = new NonTerminal("OBJETO");
            NonTerminal CONSTRUCTOR = new NonTerminal("CONSTRUCTOR");
            NonTerminal PARAMETROS = new NonTerminal("PARAMETROS");
            NonTerminal METODO = new NonTerminal("METODO");
            NonTerminal FUNCIONES = new NonTerminal("FUNCIONES");
            NonTerminal OVERRIDE = new NonTerminal("OVERRIDE");
            NonTerminal ACCESO = new NonTerminal("ACCESO");
            NonTerminal THIS = new NonTerminal("THIS");
            NonTerminal ATRIBUTOS = new NonTerminal("ATRIBUTOS");
            NonTerminal COMENTARIOS = new NonTerminal("COMENTARIOS");
            NonTerminal CONDICION = new NonTerminal("CONDICION");
            NonTerminal IF = new NonTerminal("IF");
            NonTerminal COMPARACION = new NonTerminal("COMPARACION");
            NonTerminal OPLOGICO = new NonTerminal("OPLOGICO");
            NonTerminal LSEN = new NonTerminal("LSEN");
            NonTerminal ELSE = new NonTerminal("ELSE");
            NonTerminal SWITCH = new NonTerminal("SWITCH");
            NonTerminal CASO = new NonTerminal("CASE");
            NonTerminal WHILE = new NonTerminal("WHILE");
            NonTerminal DO = new NonTerminal("DO");
            NonTerminal FOR = new NonTerminal("FOR");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal RETURN = new NonTerminal("RETURN");
            NonTerminal OPLOGICO2 = new NonTerminal("OPLOGICO2");
            NonTerminal DECLARACIONES_FUNCIONES = new NonTerminal("DECLARACIONES_FUNCIONES");
            NonTerminal INSTRUCCIONES_FUNCIONES = new NonTerminal("INSTRUCCIONES_FUNCIONES");
            NonTerminal DECLARACIONES_CONSTRUCTOR = new NonTerminal("DECLARACIONES_CONSTRUCTOR");
            NonTerminal INSTRUCCIONES_CONSTRUCTOR = new NonTerminal("INSTRUCCIONES_CONSTRUCTOR");
            NonTerminal DECLARACIONES_METODO = new NonTerminal("DECLARACIONES_METODO");
            NonTerminal INSTRUCCIONES_METODO = new NonTerminal("INSTRUCCIONES_METODO");
            NonTerminal DECLARACIONES_CICLO = new NonTerminal("DECLARACIONES_CICLO");
            NonTerminal INSTRUCCIONES_CICLO = new NonTerminal("INSTRUCCIONES_CICLO");
            #endregion

            #region Grammars
            S.Rule = INICIO;

            INICIO.Rule = AMBITO + clase + id + EXTENDS + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;

            INICIO.ErrorRule = SyntaxError + corcheteAbrierto;

            EXTENDS.Rule = extiende + id
                | Empty;

            AMBITO.Rule = publica
              | privada
              | protegido
              | Empty;

            INSTRUCCIONES.Rule = INSTRUCCIONES + DECLARACIONES
                | DECLARACIONES;

            DECLARACIONES.Rule = VARIABLES//------------------DECLARACIONES
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
                | continuar + puntoycoma;

            INSTRUCCIONES_FUNCIONES.Rule = INSTRUCCIONES_FUNCIONES + DECLARACIONES_FUNCIONES
               | DECLARACIONES_FUNCIONES;

            DECLARACIONES_FUNCIONES.Rule = VARIABLES//------------------DECLARACIONES FUNCIONES
                                                    // | CONSTRUCTOR
                                                    // | METODO
                                                    //| FUNCIONES
                                                    //| OVERRIDE
                | IF
                | SWITCH
                | WHILE
                | DO
                | FOR
                | RETURN//------componer los parentesis
                | freno + puntoycoma
                | continuar + puntoycoma;

            INSTRUCCIONES_CONSTRUCTOR.Rule = INSTRUCCIONES_CONSTRUCTOR + DECLARACIONES_CONSTRUCTOR
               | DECLARACIONES_CONSTRUCTOR;

            DECLARACIONES_CONSTRUCTOR.Rule = VARIABLES//------------------DECLARACIONES CONSTRUCTOR
                                                      // | CONSTRUCTOR
                                                      //| METODO
                                                      //| FUNCIONES
                                                      //| OVERRIDE
                | IF
                | SWITCH
                | WHILE
                | DO
                | FOR
                //| RETURN//------componer los parentesis
                | freno + puntoycoma
                | continuar + puntoycoma;

            INSTRUCCIONES_METODO.Rule = INSTRUCCIONES_METODO + DECLARACIONES_METODO
                | DECLARACIONES_METODO;

            DECLARACIONES_METODO.Rule = VARIABLES//------------------DECLARACIONES METODO
                                                 //| CONSTRUCTOR
                                                 //| METODO
                                                 //| FUNCIONES
                                                 //| OVERRIDE
                | IF
                | SWITCH
                | WHILE
                | DO
                | FOR
                // | RETURN//------componer los parentesis
                | freno + puntoycoma
                | continuar + puntoycoma;

            INSTRUCCIONES_CICLO.Rule = INSTRUCCIONES_CICLO + DECLARACIONES_CICLO
               | DECLARACIONES_CICLO;

            DECLARACIONES_CICLO.Rule = VARIABLES//------------------DECLARACIONES CICLO
                                                //| CONSTRUCTOR
                                                //| METODO
                                                //| FUNCIONES
                                                //| OVERRIDE
                | IF
                | SWITCH
                | WHILE
                | DO
                | FOR
                | RETURN//------componer los parentesis
                | freno + puntoycoma
                | continuar + puntoycoma;



            //| ACCESO;
            //-----------------------------------------------------------------------VARIABLES
            VARIABLES.Rule = AMBITO + TIPO + L_ID + INICIALIZAR;
            VARIABLES.ErrorRule = SyntaxError + puntoycoma;
            // | ACCESO;

            // ATRIBUTOS.Rule = AMBITO + TIPO;
            //| Empty;

            TIPO.Rule = entero
                | String
                | boolean
                | doble
                | Char
                | OBJETO;
            //| Empty;



            L_ID.Rule = L_ID + coma + id
                | L_ID + punto + id
                | id
                | L_ID + mas + mas
                | L_ID + menos + menos
                // |L_ID+parentesisAbierto+PARAMETROS+parentesisCerrado
                | Empty;

            INICIALIZAR.Rule = puntoycoma
                | igual + EXPRESION + puntoycoma
                | igual + nulo + puntoycoma
                | igual + L_ID + puntoycoma
                // |INICIALIZAR+igual+OBJETO+puntoycoma
                //|igual + OBJETO+puntoycoma
                | igual + nuevo + id + parentesisAbierto + PARAMETROS + parentesisCerrado + puntoycoma;

            OBJETO.Rule = OBJETO + punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                | punto + id + parentesisAbierto + PARAMETROS + parentesisCerrado
                | OBJETO + punto + id
                | punto + id
                | id
                | id + parentesisAbierto + PARAMETROS + parentesisCerrado
                | Empty;

            EXPRESION.Rule = EXPRESION + mas + EXPRESION
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
                    //| EXPRESION + parentesisAbierto + EXPRESION
                    //| EXPRESION + parentesisCerrado + EXPRESION
                    | EXPRESION + OBJETO;
            //-------------------------------------------------------------------CONSTRUCTOR
            CONSTRUCTOR.Rule = AMBITO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CONSTRUCTOR + corcheteCerado;


            PARAMETROS.Rule = PARAMETROS + coma + TIPO + id
                | TIPO + id
                | PARAMETROS + coma + id
                | id
                | PARAMETROS + coma + num
                | num
                | tcadena
                | PARAMETROS + EXPRESION
                | Empty;
            //------------------------------------------------------------METODO
            METODO.Rule = AMBITO + Void + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES + corcheteCerado;
            // METODO.ErrorRule = SyntaxError + corcheteCerado;
            //---------------------------------------------------------FUNCIONES
            FUNCIONES.Rule = AMBITO + TIPO + id + parentesisAbierto + PARAMETROS + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_FUNCIONES + corcheteCerado;
            //-----------------------------------------------------------------------OVERRIDE
            OVERRIDE.Rule = arroba + ov + METODO
                | arroba + ov + FUNCIONES;
            //-------------------------------------------------------------ACCESO
            //ACCESO.Rule = L_ID+puntoycoma;
            //----------------------------------------------------IF
            IF.Rule = si + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + LSEN;

            CONDICION.Rule = EXPRESION + COMPARACION + EXPRESION + OPLOGICO;

            COMPARACION.Rule = menor
                | mayor
                | menorIgual
                | mayorIgual
                | dobleIgual
                | diferente;

            OPLOGICO.Rule = and + CONDICION
                | or + CONDICION
                | not + CONDICION
                | Empty;

            LSEN.Rule = LSEN + sino + ELSE
                | sino + ELSE
                | Empty;

            ELSE.Rule = IF
                | corcheteAbrierto + INSTRUCCIONES + corcheteCerado;
            //| Empty;
            /////-------------------------------------------SWITCH
            SWITCH.Rule = Switch + parentesisAbierto + EXPRESION + parentesisCerrado + corcheteAbrierto + caso + EXPRESION + dospuntos + INSTRUCCIONES_CICLO + freno + puntoycoma + CASO + defa + dospuntos + INSTRUCCIONES + freno + puntoycoma + corcheteCerado;


            CASO.Rule = CASO + caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                | caso + EXPRESION + dospuntos + INSTRUCCIONES + freno + puntoycoma
                | Empty;
            //-----------------------------------------------------------WHILE
            WHILE.Rule = mientras + parentesisAbierto + CONDICION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;
            //-------------------------------------------------------DO-WHILE
            DO.Rule = hacer + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado + mientras + parentesisAbierto + CONDICION + parentesisCerrado + puntoycoma;
            //-------------------------------------------------------FOR
            FOR.Rule = For + parentesisAbierto + EXPRESION + igual + EXPRESION + puntoycoma + CONDICION + puntoycoma + ASIGNACION + parentesisCerrado + corcheteAbrierto + INSTRUCCIONES_CICLO + corcheteCerado;

            ASIGNACION.Rule = EXPRESION + mas + mas
                | EXPRESION + menos + menos
                | EXPRESION + igual + EXPRESION;
            //---------------------------------------------------------RETURN
            RETURN.Rule = regresar + puntoycoma
                | regresar + EXPRESION + puntoycoma
                | regresar + EXPRESION + OPLOGICO2;

            OPLOGICO2.Rule = OPLOGICO2 + and + EXPRESION
                | OPLOGICO2 + or + EXPRESION
                | OPLOGICO2 + not + EXPRESION
                | and + EXPRESION
                | or + EXPRESION
                | not + EXPRESION
                | Empty;
            #endregion
            
            #region Preferences
            this.Root = S;
            MarkPunctuation(IF,FOR,WHILE,DO,SWITCH,CASO);
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, por, division);
            this.RegisterOperators(3, Associativity.Left, elev);
            #endregion

        }
    }
}
