# DeviceTracking application/uygulaması

<h3>Descreption / Açıklama</h3>
<p>
Teknik servis içerisinde müdahale edilen cihazların takibi, girişleri, çıkışları, düzenlemeleri ve raporlamaları sağlar.<br /> Tak-çalıştır taşınabilir ve platform bağımsız bir program olarak tasarlandı.
</p>
<p>
It provides tracking, entrances, exits, regulations and reporting of the devices that are intervened in the technical service.<br /> It was designed as a plug-and-play portable and platform independent program.
</p>
<hr />

<h3>Development process / Geliştirme süreci</h3>
<p>
 Bu program geliştirilirken taşınabilir, platform bağımsız ve gelişmiş olabilmesi için; electron js, angular ve .net core 3.1 teknoljileri kullanıldı.<br />
.net core projesi publish edildikten sonra electron içerisinde node.js yardımı ile bir child process olarak web api şeklinde çalıştırıldı. <br />
Bu sayede electron içerisinde kullanılan angular 11 ile apiye gerekli istekler atılıp haberleşme kolay bir şekilde sağlanmış oldu.
</p>

<p>
While this program is being developed, in order to be portable, platform independent and developed; electron js, angular and .net core 3.1 technologies were used.
After publishing the .net core project, it was run as a web api as a child process with the help of node.js in electron.
In this way, with the angular 11 used in the electron, the requests required for api were sent and the communication was provided easily.
</p>

<h4>Used technologies / Kullanılan teknolojiler</h4>
<ul>
 <li>C#</li>
 <li>Typescript</li>
 <li>.Net core 3.1</li>
 <li>Npoi excel reporting</li>
 <li>Sqlite</li>
 <li>Entity framework core</li>
 <li>Unit of work design pattern</li>
 <li>Repository design pattern</li>
 <li>Electron js</li>
 <li>Node js</li>
 <li>Angular 11</li>
 <li>PrimeNg</li>
</ul>
