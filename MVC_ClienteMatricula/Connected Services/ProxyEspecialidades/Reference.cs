﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_ClienteMatricula.ProxyEspecialidades {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DCEspecialidad", Namespace="http://schemas.datacontract.org/2004/07/WCF_Matriculas")]
    [System.SerializableAttribute()]
    public partial class DCEspecialidad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int cantProfesoresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codEspField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string desEspField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int cantProfesores {
            get {
                return this.cantProfesoresField;
            }
            set {
                if ((this.cantProfesoresField.Equals(value) != true)) {
                    this.cantProfesoresField = value;
                    this.RaisePropertyChanged("cantProfesores");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codEsp {
            get {
                return this.codEspField;
            }
            set {
                if ((object.ReferenceEquals(this.codEspField, value) != true)) {
                    this.codEspField = value;
                    this.RaisePropertyChanged("codEsp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string desEsp {
            get {
                return this.desEspField;
            }
            set {
                if ((object.ReferenceEquals(this.desEspField, value) != true)) {
                    this.desEspField = value;
                    this.RaisePropertyChanged("desEsp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyEspecialidades.IEspecialidad")]
    public interface IEspecialidad {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/ListarEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/ListarEspecialidadResponse")]
        MVC_ClienteMatricula.ProxyEspecialidades.DCEspecialidad[] ListarEspecialidad();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/ListarEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/ListarEspecialidadResponse")]
        System.Threading.Tasks.Task<MVC_ClienteMatricula.ProxyEspecialidades.DCEspecialidad[]> ListarEspecialidadAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEspecialidadChannel : MVC_ClienteMatricula.ProxyEspecialidades.IEspecialidad, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EspecialidadClient : System.ServiceModel.ClientBase<MVC_ClienteMatricula.ProxyEspecialidades.IEspecialidad>, MVC_ClienteMatricula.ProxyEspecialidades.IEspecialidad {
        
        public EspecialidadClient() {
        }
        
        public EspecialidadClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EspecialidadClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EspecialidadClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EspecialidadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MVC_ClienteMatricula.ProxyEspecialidades.DCEspecialidad[] ListarEspecialidad() {
            return base.Channel.ListarEspecialidad();
        }
        
        public System.Threading.Tasks.Task<MVC_ClienteMatricula.ProxyEspecialidades.DCEspecialidad[]> ListarEspecialidadAsync() {
            return base.Channel.ListarEspecialidadAsync();
        }
    }
}
