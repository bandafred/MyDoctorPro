import * as React from "react";
import styles from "./SidebarRight.module.css";

const SidebarRight = () => (
	<div className={styles.sidebar}>
		<section className={styles.donate}>
			<iframe
				src="https://money.yandex.ru/quickpay/shop-widget?writer=seller&targets=%D0%9F%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%B0%20%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B0&targets-hint=&default-sum=50&button-text=11&payment-type-choice=on&mobile-payment-type-choice=on&hint=&successURL=&quickpay=shop&account=410014360250342"
				width="190"
				height="265"
				// frameborder="0"
				// allowtransparency="true"
				scrolling="no"
			></iframe>
		</section>
	</div>
);

export default SidebarRight;
