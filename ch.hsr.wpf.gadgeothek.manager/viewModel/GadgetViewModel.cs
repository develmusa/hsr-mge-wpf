﻿using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.manager.model;
using ch.hsr.wpf.gadgeothek.service;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ch.hsr.wpf.gadgeothek.manager.viewModel
{
    public class GadgetViewModel : INotifyPropertyChanged
    {
        private GadgetModel GadgetModel;
        private List<Gadget> _gadgets;
        public List<Gadget> GadgetsList
        {
            get { return _gadgets;}
            set
            {
                _gadgets = value;
                NotifyPropertyChanged("GadgetsList");
            }
        }
        public ServiceHandler serviceHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand DeleteRequestCommand { get; set; }
        public ICommand AddRequestCommand { get; set; }
        public Gadget SelectedGadget { get; set; }
        public Gadget MarkedToDeleteGadget { get; set; }

        public GadgetViewModel(GadgetModel GadgetModel, ServiceHandler serviceHandler)
        {            
            this.GadgetModel = GadgetModel;
            this.serviceHandler = serviceHandler;
            DeleteRequestCommand = new RelayCommand(this.DeleteRequest);
            AddRequestCommand = new RelayCommand(this.AddRequest);
            GadgetModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Gadget_PropertyChanged);

            Messenger.Default.Register<NotificationMessage>(this, (message) =>
            {
                switch (message.Notification)
                {
                    case "Delete_Gadget_Cancel":
                        DeleteCancel();
                        break;

                    case "Delete_Gadget_Ok":
                        DeleteGadget();
                        break;
                }
            });
        }

        private void DeleteRequest()
        {
            if (SelectedGadget != null) {
                Debug.WriteLine("Delete:    " + SelectedGadget + "    Type:   " + SelectedGadget.GetType());
                MarkedToDeleteGadget = SelectedGadget;
                Messenger.Default.Send(new NotificationMessage("Delete_Gadget"));
            }

        }

        private void DeleteGadget()
        {
            serviceHandler.DeleteGadget(MarkedToDeleteGadget);
            MarkedToDeleteGadget = null;
            serviceHandler.RefreshGadgets();
        }

        private void DeleteCancel()
        {
            MarkedToDeleteGadget = null;
        }

        private void AddRequest()
        {
            Debug.WriteLine(" GadgetViewModel| AddRequest()");
            Messenger.Default.Send(new NotificationMessage("Add_Gadget"));
        }

        public void Update()
        {
            GadgetsList = GadgetModel.Gadgets;
        }

        private void Gadget_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Update();
        }
    }
}
