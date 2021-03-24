using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public class Entity
    {
        public int id;
        public int type;
        public string name;
        public string[] lod;
    }

    public class EntityMap : ITab
    {
        private Label entitiCount_label;
        private ListView entityMap_listView;

        private List<Entity> entityList = new List<Entity>();

        private string prevEntityMsg = "";
        private int entityCount = 0;

        public EntityMap(ListView EntityMap_listView, Label EntitiCount_label)
        {
            entityMap_listView = EntityMap_listView;
            entitiCount_label = EntitiCount_label;
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getEntityMap();

        public void updateValue()
        {
            IntPtr arrayValue = getEntityMap();

            if (arrayValue == null)
                return;
           
            var frameTimeDict = arrayValue.ToStringString();

            if (frameTimeDict["SharedMemoryInit"] == "1")
            {
                EnableControl(true);

                string entityMsg = frameTimeDict["EntityMapMessage"];

                if (entityMsg == prevEntityMsg)
                    return;

                entityCount = frameTimeDict["EntityMapCount"].ToInt32();

                updateEntityList(entityMsg);

                updateControl();

                prevEntityMsg = entityMsg;
            }
            else
            {
                clearData();

                EnableControl(false);
            }
        }

        private void clearData()
        {
            entityList.Clear();
            updateControl();
        }

        public override void EnableControl(bool enable)
        {
            entitiCount_label.Enabled = enable;
            entityMap_listView.Enabled = enable;
        }

        private void updateControl()
        {
            entityMap_listView.Items.Clear();

            foreach ( var entity in entityList)
            {
                ListViewItem listViewItem = new ListViewItem();

                listViewItem.Text = entity.name;
                listViewItem.SubItems.Add(entity.id.ToString());
                listViewItem.SubItems.Add(entity.type.ToString());
                listViewItem.SubItems.Add(string.Join(",", entity.lod).TrimEnd(','));

                entityMap_listView.Items.Add(listViewItem);
            }

            entitiCount_label.Text = entityCount.ToString();
        }

        private void updateEntityList(string msg)
        {
            entityList.Clear();

            string[] entityMapMsg = msg.Split('~');

            foreach (var entityMsg in entityMapMsg)
            {
                if (entityMsg == "")
                    continue;
                Entity entity = CreateEntity(entityMsg);

                entityList.Add(entity);
            }
        }

        private Entity CreateEntity(string msg)
        {
            string[] splitStr = msg.Split(';');

            Entity entity = new Entity();
            entity.id = splitStr[0].ToInt32();
            entity.type = splitStr[1].ToInt32();
            entity.name = splitStr[2];
            entity.lod = splitStr[3].Split(',');

            return entity;
        }
    }
}
