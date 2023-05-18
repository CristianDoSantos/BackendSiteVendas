﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackendSiteVendas.Exceptions {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceCustomErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceCustomErrorMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BackendSiteVendas.Exceptions.ResourceCustomErrorMessages", typeof(ResourceCustomErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email address you entered is already registered in the database!.
        /// </summary>
        public static string EMAIL_ALREADY_REGISTERED {
            get {
                return ResourceManager.GetString("EMAIL_ALREADY_REGISTERED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s email is required..
        /// </summary>
        public static string BLANK_USER_EMAIL {
            get {
                return ResourceManager.GetString("BLANK_USER_EMAIL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s emailis is invalid..
        /// </summary>
        public static string INVALID_USER_EMAIL {
            get {
                return ResourceManager.GetString("INVALID_USER_EMAIL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Unknown error..
        /// </summary>
        public static string UNKNOWN_ERROR {
            get {
                return ResourceManager.GetString("UNKNOWN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The email and/or password are invalid..
        /// </summary>
        public static string INVALID_LOGIN {
            get {
                return ResourceManager.GetString("INVALID_LOGIN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Current password invalid..
        /// </summary>
        public static string INVALID_CURRENT_PASSWORD {
            get {
                return ResourceManager.GetString("INVALID_CURRENT_PASSWORD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s password is required..
        /// </summary>
        public static string BLANK_USER_PASSWORD {
            get {
                return ResourceManager.GetString("BLANK_USER_PASSWORD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s password mus have at least 6 characteres..
        /// </summary>
        public static string USER_PASSWORD_MIN_SIX_CHARACTERES {
            get {
                return ResourceManager.GetString("USER_PASSWORD_MIN_SIX_CHARACTERES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s phone number is required..
        /// </summary>
        public static string BLANK_USER_PHONE {
            get {
                return ResourceManager.GetString("BLANK_USER_PHONE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s phone numbers must be at the format XX X XXXX-XXXX.
        /// </summary>
        public static string INVALID_USER_PHONE {
            get {
                return ResourceManager.GetString("INVALID_USER_PHONE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Login again on the App..
        /// </summary>
        public static string EXPIRED_TOKEN {
            get {
                return ResourceManager.GetString("EXPIRED_TOKEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The user´s name is required..
        /// </summary>
        public static string BLANK_USER {
            get {
                return ResourceManager.GetString("BLANK_USER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a You are not allowed to access this feature..
        /// </summary>
        public static string INVALID_USER {
            get {
                return ResourceManager.GetString("INVALID_USER", resourceCulture);
            }
        }
    }
}
