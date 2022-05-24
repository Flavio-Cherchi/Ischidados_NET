<%@ Page Language="C#" AutoEventWireup="true" Inherits="regulation" MasterPageFile="~/Masterpage.Master" EnableViewStateMac="false"  Codebehind="regulation.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-lg animate__animated animate__fadeIn">

    <div class="customJumbotron rounded">
        <center><h1 runat="server" id="divIschidados">Regolamento Ischidados GdR</h1>
<img class="img-fluid" src="Assets/img/Base/logo.jpg" alt="babyIschidados" style="max-height:400px; border-radius:15px;" /></center>
        <br /><br />
<h3>Premessa gdr e scopo del gioco</h3>

<p class="text-justify">Per quanto <b>Ischidados GdR - I Risvegliati</b> sia definito come GdR, cioè gioco di ruolo, ha corpose caratteristiche tipiche dei giochi gestionali e strategici. L'ambientazione è post apocalisse zombie, la narrazione è limitata alla Sardegna e convenzionalmente le partite vengono ambientate nel tempo presente.</p>

<p class="text-justify">Ogni giocatore ha il controllo di una comunità di persone che cerca di sopravvivere e di tornare alla civiltà. Lo scopo è di far sopravvivere la propria comunità, arrivando ad avere almeno cinquanta persone sotto la propria area d'influenza o divise tra la propria comunità e quelle neutrali con cui si ha lo status di "affiliato".</p>

<p class="text-justify">N.b. questa è la regola di default quando si comincia una partita. Il master - ovvero chi crea la partita - può però decidere di modificare in fase di creazione l'obiettivo finale, scegliendone un altro o lasciando la partita libera e senza una fine prestabilita</p>
<br />
<h3>Il turno</h3>

<p class="text-justify">In gdr il turno dura un mese, tempo rilevante per la lunghezza dei viaggi fattibili, il numero di risorse prodotte e consumate e la stagione in cui ci si trova.</p>
<br />
<h3>La comunità</h3>

<p class="text-justify">Ogni comunità inizia con tre persone; inizialmente non si conoscono tra di loro e non hanno particolari doti; il giocatore può scegliere il loro nome e cognome (tra una lista di quelli consentiti) e una tra le quattro indoli: violento, collaborativo, asociale, opportunista. Può inoltre scrivere una breve biografia del personaggio, che influirà unicamente a discrezione del Master.</p>

<p class="text-justify">Le tre persone iniziali sono i Personaggi Principali (da qui in poi chiamati PP); si differenziano dai Personaggi Secondari (i PS, ovvero tutti gli altri membri della comunità, quando crescerà) in quanto hanno determinate caratteristiche principali; inoltre solo i PP possono capeggiare viaggi.</p>

<p class="text-justify">Ogni turno la comunità ha la possibilità (non l'obbligo) di accettare un nuovo PS. Ci possono essere eventi random o legati alle azioni dei giocatori che aumentano o riducono il numero dei PS. </p>

<p class="text-justify">Ogni due turni la comunità ha all'inizio del gioco un 50% di probabilità di subire degli attacchi zombie. Tale percentuale può aumentare o diminuire a seconda del tipo di gioco svolto, delle ricerche fatte, di eventi e di altri fattori gdr influenzabili dal master o da altri giocatori. La comunità cessa di esistere quando nessuno sopravvive (quindi se si ha ancora almeno una persona, si è ancora in gioco).</p>

<p class="text-justify">I Personaggi Principali sono sempre tre, a patto ovviamente di avere almeno tre persone nella propria comunità. Se uno dei PP muore e si ha almeno un PS a disposizione, questi diventerà un PP e si potra scegliere la sua indole e scrivere il suo background.</p>
<br />
<h3>Le indoli e l'esperienza</h3>

<p class="text-justify">Come già detto, le indoli dei PP sono quattro: violento, collaborativo, asociale ed opportunista. Oltre ad essere caratteristiche utili per definire meglio a livello ruolistico i propri personaggi, influenzano notevolmente la partita a livello strategico e gestionale.</p>

<p class="text-justify">Ogni PP accumula esperienza relativa alla propria indole: </p>
    <ul>
        <li><b>Esperienza violenta</b>: indica quanto un PP è propenso ed abituato ad usare violenza, sia contro zombie, sia contro esseri umani. Un PP con indole violenta ottiene +1 di esperienza violenta a turno, ne può ottenere di aggiuntiva se compie azioni violente. L'esperienza violenta si può utilizzare in combattimento per avere vantaggi sul nemico.</li>
        <li><b>Esperienza collaborativa</b>: determinano quanto un PP è capace di lavorare in gruppo e la sua capacità diplomatica. Un PP con indole collaborativa ottiene +1 di esperienza collaborativa a turno e può ottenerne altra se occupato in azioni di diplomazia o se lavora insieme ad altri PP. L'esperienza collaborativa si può usare per migliorare il risultato di uno scambio diplomatico e per mantenere stabili o migliorare le relazioni con altre comunità</li>
        <li><b>Esperienza asociale</b>: se un PP ha il tratto asociale, è propenso a non voler conoscere nuove persone e si fiderà solo di quelle della propria comunità. Riceve +1 di esperienza asociale a turno e ne può ottenere altra facendo lavori all'interno della comunità. Inoltre ogni turno senza viaggi (se si ha almeno un PP asociale) può generare esperienza asociale. Tale esperienza possono essere usata per migliorare i costi di costruzione e la resa degli edifici produttivi.</li>
        <li><b>Esperienza opportunista</b>: i PP opportunisti vengono utilizzati nel commercio e nei furti. Ogni PP opportunista genera +1 di esperienza omonima a turno, può esserne generata altra commerciando con altre comunità o compiendo furti (tramite evento, durante i viaggi o mentre si sta commerciando). Questo tipo di esperienza incideo favorevolmente quando usata durante il commercio e i furti</li>
    </ul>

<p class="text-justify">N.b. oltre che con i PP, l'esperienza viene generata anche con eventi e con i viaggi. Come si può facilmente notare, un'azione può tanto generare, quanto necessitare di esperienza. L'esperienza può essere però solo usata o solo generata in una particolare situazione. Ad esempio durante un commercio con un'altra comunità un giocatore può usare esperienza opportunista (se ne ha disponibili) per migliorare quel commercio, oppure può non usarla e vedersene generata. Sta al giocatore, alle sue disponibilità e alla sua strategia decidere come usarli.</p>

<p class="text-justify">N.b.2: attenzione! L'esperienza è legata al singolo PP! Se questi muore, tutta o parte dei punti esperienza associati alla sua indole verranno persi!</p>

<p class="text-justify">É possibile cambiare l'indole dei PP, questo determinerà la perdita di tutta l'esperienza legata alla vecchia e alla nuova indole. Inoltre per un anno (dodici turni) il PP che ha modificato la sua indole non genererà alcuna esperienza</p>

<br />
<h3>TODO</h3>


    </div>
        </div>

</asp:Content>

<asp:Content ID="LastContent" runat="server" ContentPlaceHolderID="JSContent">
 

</asp:Content>
