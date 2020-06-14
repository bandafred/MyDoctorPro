import * as React from "react";
import styles from "./Footer.module.css";

let Year = () => new Date().getFullYear();

const Footer = () => (
	<div className={styles.footer}>
		<div className={styles.confidence}>
			<a href="#" className={styles.linkPolicy}>
				Политика конфиденциальности
			</a>
		</div>
		<div className={styles.copyright}>
			<span>&copy; 2016 - {Year()} </span>
			<a
				href="http://goldstepstudio.ru/"
				target="_blank"
				className={styles.link}
			>
				GoldStepStudio
			</a>
			<span> All rights reserved.</span>
		</div>
	</div>
);

export default Footer;
