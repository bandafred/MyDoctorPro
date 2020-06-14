import * as React from "react";
import { Layout } from "antd";
import Top from "./Header/Header";
import SidebarLeft from "./SidebarLeft/SidebarLeft";
import SidebarRight from "./SidebarRight/SidebarRight";
import Bottom from "./Footer/Footer";
import styles from "./Layout.module.css";

const { Header, Footer, Sider, Content } = Layout;

export default (props: { children?: React.ReactNode }) => (
	<React.Fragment>
		<Layout>
			<Header className={styles.header}>
				<Top />
			</Header>
			<Layout className={styles.wrapper}>
				<SidebarLeft />
				<Content className={styles.main}>{props.children}</Content>
				<Sider theme="light" className={styles.sidebarRight}>
					<SidebarRight />
				</Sider>
			</Layout>
			<Footer className={styles.footer}>
				<Bottom />
			</Footer>
		</Layout>
	</React.Fragment>
);
