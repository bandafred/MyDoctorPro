import * as React from "react";
import {Layout, Tooltip} from "antd";
import Logo from "./../../common/img/logo.png";
import styles from "./Header.module.css";
import {Link} from "react-router-dom";
import {UserHeaderLayout} from "../Forms/User/UserHeaderLayout/UserHeaderLayout";

const {Sider, Content} = Layout;

const Header = () => {
    return (

        <div className={styles.header}>
            <Layout>
                <Sider className={styles.logo}>
                    <Link to={"/"}>
                        <img
                            className={styles.image}
                            src={Logo}
                            alt="Логотип Goldstepstudio"
                        />
                    </Link>
                </Sider>
                <Content className={styles.site_name}>
                    <span className={styles.name}>Виртуальный помощник для медицинских работников и пациентов</span>
                </Content>
                <Sider className={styles.authorisation}>
                    <UserHeaderLayout/>
                </Sider>
            </Layout>
        </div>
    );
}
export default Header;
