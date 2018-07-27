using System;
using System.Collections.Generic;
using System.Text;

namespace ChangePassword
{
    /// <summary>
    /// 網域認證物件
    /// </summary>
    public class DomainListObj
    {
        /// <summary>
        /// 網域清單集合
        /// </summary>
        public List<DomainListItem> Items { get; set; }

        /// <summary>
        /// 初始化DomainListObj的動作
        /// </summary>
        public DomainListObj()
        {
            // 要增加認證網域的清單,請在這裡加入新項目
            this.Items = new List<DomainListItem>();
            this.Items.Add(new DomainListItem("192.168.50.6", "CEEC", "Administrator", "P@ssw0rd", "LDAP://ceec.intranet/dc=ceec,dc=intranet"));
            this.Items.Add(new DomainListItem("192.168.50.7", "IM", "maduka", "2wsx4rfv6yhn", "LDAP://im.ceec.edu.tw/dc=im,dc=ceec,dc=edu,dc=tw"));
        }

        /// <summary>
        /// 網域清單項目
        /// </summary>
        public class DomainListItem
        {
            /// <summary>
            /// 網域IP
            /// </summary>
            public string DomainIP { get; set; }
            /// <summary>
            /// 網域名稱
            /// </summary>
            public string DomainName { get; set; }
            /// <summary>
            /// 網域admin帳號
            /// </summary>
            public string DomainAdmin { get; set; }
            /// <summary>
            /// 網域admin密碼
            /// </summary>
            public string DomainAdminPwd { get; set; }
            /// <summary>
            /// 網域LDAP
            /// </summary>
            public string DomainLDAP { get; set; }

            /// <summary>
            /// 建立新的網域清單物件
            /// </summary>
            /// <param name="strDomainIP">網域IP</param>
            /// <param name="strDomainName">網域名稱</param>
            /// <param name="strDomainAdmin">網域admin帳號</param>
            /// <param name="strDomainAdminPwd">網域admin密碼</param>
            /// <param name="strDomainLDAP">網域LDAP</param>
            public DomainListItem(string strDomainIP, string strDomainName, string strDomainAdmin, string strDomainAdminPwd, string strDomainLDAP)
            {
                this.DomainIP = strDomainIP;
                this.DomainName = strDomainName;
                this.DomainAdmin = strDomainAdmin;
                this.DomainAdminPwd = strDomainAdminPwd;
                this.DomainLDAP = strDomainLDAP;
            }
        }
    }
}
