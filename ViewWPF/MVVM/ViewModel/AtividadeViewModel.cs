using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel {
    class AtividadeViewModel : INotifyPropertyChanged {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged([CallerMenberName] string propertuName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region CamposModelAtividade
        private int atividadeID;

        public int AtividadeID {
            get { return atividadeID; }

            set {
                atividadeID = value;
                NotifyPropertyChanged("AtividadeID");
            }

        }

        private string titulo {
            get { return titulo; }

            set {
                titulo = value;
                NotifyPropertyChanged("titulo");
            }
        }

        private string descricao;

        public string Descricao {
            get { return descricao; }

            set {
                descricao = value;
                NotifyPropertyChanged("Descrição");

            }
        }

        private bool ativo;

        public bool Ativo {
            get { return ativo; }

            set {
                ativo = value;
                NotifyPropertyChanged("Ativo");

            }
        }

    }
    #endregion
}
}
